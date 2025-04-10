const { test, expect } = require('@playwright/test');

const host = 'http://localhost:3000';

let user = {
    email: `user${Math.floor(Math.random() * 1000000)}@test.com`,
    password: "123456",
    confirmPass: "123456",
};

let albumName = "";

test.describe('E2E tests', () => {
    test.setTimeout(120000);

    test.beforeEach(async ({ page }) => {
        page.setDefaultTimeout(120000);
        page.setDefaultNavigationTimeout(120000);
        await page.goto(host);
    });

    test.describe('Authentication', () => {
        test.setTimeout(120000);

        test('register works', async ({ page }) => {
            page.setDefaultTimeout(120000);
            await page.click('nav a:has-text("Register")');
            await page.waitForSelector('//section[@id="registerPage"]');
            
            await page.fill('#email', user.email);
            await page.fill('#password', user.password);
            await page.fill('#conf-pass', user.confirmPass);
            
            await page.click('button.register');
            await page.waitForSelector('nav >> text=Logout');
        });

        test('login works', async ({ page }) => {
            page.setDefaultTimeout(120000);
            await page.click('nav a:has-text("Login")');
            await page.waitForSelector('//section[@id="loginPage"]');
            
            await page.fill('#email', user.email);
            await page.fill('#password', user.password);
            
            await page.click('button.login');
            await page.waitForSelector('nav >> text=Logout');
        });

        test('logout works', async ({ page }) => {
            page.setDefaultTimeout(120000);
            await page.click('nav a:has-text("Login")');
            await page.fill('#email', user.email);
            await page.fill('#password', user.password);
            await page.click('button.login');
            
            await page.click('nav a:has-text("Logout")');
            await page.waitForSelector('nav a:has-text("Login")');
        });
    });

    test.describe('Navigation', () => {
        test.setTimeout(120000);

        test('logged user should see correct navigation', async ({ page }) => {
            page.setDefaultTimeout(120000);
            await page.click('nav a:has-text("Login")');
            await page.fill('#email', user.email);
            await page.fill('#password', user.password);
            await page.click('button.login');

            await expect(page.locator('nav a:has-text("Home")')).toBeVisible();
            await expect(page.locator('nav a:has-text("Catalog")')).toBeVisible();
            await expect(page.locator('nav a:has-text("Search")')).toBeVisible();
            await expect(page.locator('nav a:has-text("Create Album")')).toBeVisible();
            await expect(page.locator('nav a:has-text("Logout")')).toBeVisible();
            await expect(page.locator('nav a:has-text("Login")')).not.toBeVisible();
            await expect(page.locator('nav a:has-text("Register")')).not.toBeVisible();
        });

        test('guest user should see correct navigation', async ({ page }) => {
            page.setDefaultTimeout(120000);
            await expect(page.locator('nav a:has-text("Home")')).toBeVisible();
            await expect(page.locator('nav a:has-text("Catalog")')).toBeVisible();
            await expect(page.locator('nav a:has-text("Search")')).toBeVisible();
            await expect(page.locator('nav a:has-text("Login")')).toBeVisible();
            await expect(page.locator('nav a:has-text("Register")')).toBeVisible();
            await expect(page.locator('nav a:has-text("Create Album")')).not.toBeVisible();
            await expect(page.locator('nav a:has-text("Logout")')).not.toBeVisible();
        });
    });

    test.describe('CRUD', () => {
        test.setTimeout(120000);

        test('create works', async ({ page }) => {
            page.setDefaultTimeout(120000);
            await page.click('nav a:has-text("Login")');
            await page.fill('#email', user.email);
            await page.fill('#password', user.password);
            await page.click('button.login');
            
            await page.click('nav a:has-text("Create Album")');
            await page.waitForSelector('//section[@id="createPage"]');
            
            albumName = `Album ${Math.floor(Math.random() * 1000000)}`;
            await page.fill('#name', albumName);
            await page.fill('#imgUrl', 'https://example.com/image.jpg');
            await page.fill('#price', '20');
            await page.fill('#releaseDate', '2024-02-15');
            await page.fill('#artist', 'Test Artist');
            await page.fill('#genre', 'Rock');
            await page.fill('#description', 'Test Description');
            
            await page.click('button.create');
            await page.waitForSelector(`text=${albumName}`);
        });

        test('edit works', async ({ page }) => {
            page.setDefaultTimeout(120000);
            
            // Login
            await page.click('nav a:has-text("Login")');
            await page.fill('#email', user.email);
            await page.fill('#password', user.password);
            await page.click('button.login');
            
            // Wait for navigation after login
            await page.waitForTimeout(2000);
            
            // Go to search page and fill the form
            await page.click('nav a:has-text("Search")');
            await page.waitForTimeout(2000);
            
            // Wait for search input and fill it
            await page.waitForSelector('input[name="search"]', { timeout: 120000 });
            await page.fill('input[name="search"]', albumName);
            
            // Click search and wait for results
            await page.click('button:has-text("Search")');
            await page.waitForTimeout(2000);
            
            // Navigate to details
            await page.waitForSelector(`a:has-text("${albumName}")`, { timeout: 120000 });
            await page.click(`a:has-text("${albumName}")`);
            await page.waitForTimeout(2000);
            
            // Click edit and wait for form
            await page.click('text=Edit');
            await page.waitForTimeout(2000);
            
            // Fill form and submit
            const newAlbumName = `Edited ${albumName}`;
            await page.fill('input[name="name"]', newAlbumName);
            await page.click('button:has-text("Save")');
            
            // Verify the edit
            await page.waitForSelector(`a:has-text("${newAlbumName}")`, { timeout: 120000 });
            await expect(page.locator(`a:has-text("${newAlbumName}"))`)).toBeVisible();
            albumName = newAlbumName;
        });

        test('delete works', async ({ page }) => {
            page.setDefaultTimeout(120000);
            await page.click('nav a:has-text("Login")');
            await page.fill('#email', user.email);
            await page.fill('#password', user.password);
            await page.click('button.login');
            
            await page.click('nav a:has-text("Search")');
            await page.waitForSelector('//section[@id="searchPage"]');
            await page.fill('#search', albumName);
            await page.click('button.search-btn');
            
            await page.click(`text=${albumName}`);
            await page.click('text=Delete');
            
            await page.waitForSelector('//section[@id="catalogPage"]');
            await expect(page.locator(`text=${albumName}`)).not.toBeVisible();
        });
    });
});
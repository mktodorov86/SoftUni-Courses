window.addEventListener("load", solve);

function solve() {
    // Get all form elements
    const numTickets = document.getElementById('num-tickets');
    const seatingPreference = document.getElementById('seating-preference');
    const fullName = document.getElementById('full-name');
    const email = document.getElementById('email');
    const phoneNumber = document.getElementById('phone-number');
    const purchaseBtn = document.getElementById('purchase-btn');

    // Get preview elements
    const ticketPreview = document.getElementById('ticket-preview');
    const purchaseSuccess = document.getElementById('purchase-success');

    // Add event listener to purchase button
    purchaseBtn.addEventListener('click', handlePurchase);

    function handlePurchase() {
        // Validate all fields are filled
        if (!numTickets.value || seatingPreference.value === 'seating-preference' || 
            !fullName.value || !email.value || !phoneNumber.value) {
            return;
        }

        // Fill preview spans
        document.getElementById('purchase-num-tickets').textContent = numTickets.value;
        document.getElementById('purchase-seating-preference').textContent = seatingPreference.value;
        document.getElementById('purchase-full-name').textContent = fullName.value;
        document.getElementById('purchase-email').textContent = email.value;
        document.getElementById('purchase-phone-number').textContent = phoneNumber.value;

        // Show preview
        ticketPreview.style.display = 'block';

        // Store original values for edit
        const originalValues = {
            numTickets: numTickets.value,
            seatingPreference: seatingPreference.value,
            fullName: fullName.value,
            email: email.value,
            phoneNumber: phoneNumber.value
        };

        // Clear form
        numTickets.value = '';
        seatingPreference.value = 'seating-preference';
        fullName.value = '';
        email.value = '';
        phoneNumber.value = '';

        // Disable purchase button
        purchaseBtn.disabled = true;

        // Add event listeners to preview buttons
        document.getElementById('edit-btn').addEventListener('click', () => handleEdit(originalValues));
        document.getElementById('buy-btn').addEventListener('click', handleBuy);
    }

    function handleEdit(originalValues) {
        // Restore form values
        numTickets.value = originalValues.numTickets;
        seatingPreference.value = originalValues.seatingPreference;
        fullName.value = originalValues.fullName;
        email.value = originalValues.email;
        phoneNumber.value = originalValues.phoneNumber;

        // Hide preview
        ticketPreview.style.display = 'none';

        // Enable purchase button
        purchaseBtn.disabled = false;
    }

    function handleBuy() {
        // Hide preview
        ticketPreview.style.display = 'none';

        // Show success message
        purchaseSuccess.style.display = 'block';

        // Add event listener to back button
        document.getElementById('back-btn').addEventListener('click', handleBack);
    }

    function handleBack() {
        // Hide success message
        purchaseSuccess.style.display = 'none';

        // Enable purchase button
        purchaseBtn.disabled = false;
    }
}
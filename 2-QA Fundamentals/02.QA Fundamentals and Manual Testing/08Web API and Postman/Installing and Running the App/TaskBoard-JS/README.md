# TaskBoard JS App + RESTful API

The JS app "Task Board" holds a board of tasks (in Trello style). Each task consists of title + description. Tasks are organized in boards, which are displayed as columns (sections): Open, In Progress, Done. The app supports the following operations:
 - Home page (view tasks count + menu): `/`
 - View the boards with tasks: `/boards`
 - Search tasks form: `/tasks/search`
 - Search tasks by keyword: `/tasks/search/:keyword`
 - View task details (by id): `/tasks/view/:id`
 - Add new task (title + description): `/tasks/create`
 - Edit task / move to board: `/tasks/edit/:id`

## Implementation Details

The app is based on Node.js + Express.js + Pug.
 - It has **no database** and app data is not persistent!

## Live Demo
 - Web app live demo: https://taskboard.nakov.repl.co
 - RESTful API live demo: https://taskboard.nakov.repl.co/api
 - Play with the code at: https://repl.it/@nakov/taskboard

## Related Projects
  - Android mobile client app: https://github.com/nakov/TaskBoard-AndroidClient
  - Windows desktop client app: https://github.com/nakov/TaskBoard-DesktopClient

## RESTful API

The following endpoints are supported:
 - `GET /api` - list all API endpoints
 - `GET /api/tasks` - list all tasks
 - `GET /api/tasks/:id` - returns a task by given `id`
 - `GET /api/tasks/search/:keyword` - list all tasks matching given keyword
 - `GET /api/tasks/board/:board` - list tasks by board
 - `POST /api/tasks` - create a new task (post a JSON object in the request body, e.g. `{"title":"Add Tests", "description":"API + UI tests", "board":"Open"}`)
 - `PATCH /api/tasks/:id` - edit task by `id` (send a JSON object in the request body, holding the fields to modify, e.g. `{"title":"changed title", "board":"Done"}`)
 - `DELETE /api/tasks/:id` - delete task by `id`
 - `GET /api/boards` - list all boards

## Screenshots

![image](https://user-images.githubusercontent.com/1689586/110086738-6a320d00-7d9b-11eb-9a59-9fd1ffbab24a.png)

![image](https://user-images.githubusercontent.com/1689586/110086832-8c2b8f80-7d9b-11eb-9d9c-3d5d94e07f3b.png)

![image](https://user-images.githubusercontent.com/1689586/110086878-9a79ab80-7d9b-11eb-97e8-1507e0f90020.png)

![image](https://user-images.githubusercontent.com/1689586/110086907-a36a7d00-7d9b-11eb-831c-5333992d560b.png)

![image](https://user-images.githubusercontent.com/1689586/110087130-edebf980-7d9b-11eb-8307-24c2eb87096d.png)

![image](https://user-images.githubusercontent.com/1689586/110087188-02c88d00-7d9c-11eb-8fb0-8d9533d72fd2.png)


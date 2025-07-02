const API_URL = import.meta.env.VITE_API_URL;

//const wait = (ms) => new Promise(resolve => setTimeout(resolve, ms));

/**
 * Fetches the list of tasks from the API.
 *
 * @async
 * @function fetchTasks
 * @throws {Error} If the network response is not ok.
 * @returns {Promise<Object[]>} A promise that resolves to an array of task objects.
 */
export async function fetchTasks() {
  //await wait(3000);
  const res = await fetch(`${API_URL}/tasks`);
  if (!res.ok) {
    throw new Error(`Failed to fetch tasks: ${res.status}`);
  }
  return await res.json();
}

/**
 * Adds a new task to the server.
 *
 * Sends a POST request to the API to create a new task.
 *
 * @async
 * @param {Object} task - The task object to add. Must include a `title` and `description`.
 * @returns {Promise<Object>} The created task object returned from the server.
 * @throws {Error} If the request fails or the server responds with a non-OK status.
 */
export async function addTask(task) {
  const res = await fetch(`${API_URL}/tasks`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(task),
  });
  if (!res.ok) {
    throw new Error(`Failed to add task: ${res.status}`);
  }
  return await res.json();
}

/**
 * Updates an existing task on the server.
 *
 * Sends a PUT request to the API to update the specified task.
 *
 * @async
 * @param {Object} task - The task object to update. Must include an `id` property.
 * @returns {Promise<Object>} The updated task object returned from the server.
 * @throws {Error} If the request fails or the server responds with a non-OK status.
 */
export async function updateTask(task) {
  const res = await fetch(`${API_URL}/tasks/${task.id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(task),
  });
  if (!res.ok) {
    throw new Error(`Failed to update task: ${res.status}`);
  }
  return await res.json();
}

/**
 * Deletes a task from the server.
 *
 * Sends a DELETE request to the API to remove the specified task.
 *
 * @async
 * @param {string} taskId - The ID of the task to delete.
 * @returns {Promise<boolean>} A promise that resolves to true if the task was deleted successfully.
 * @throws {Error} If the request fails or the server responds with a non-OK status.
 */
export async function deleteTask(taskId) {
  const res = await fetch(`${API_URL}/tasks/${taskId}`, {
    method: "DELETE",
  });
  if (!res.ok) {
    throw new Error(`Failed to delete task: ${res.status}`);
  }
  return true;
}

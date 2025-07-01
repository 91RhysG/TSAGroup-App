const API_URL = import.meta.env.VITE_API_URL;

const wait = (ms) => new Promise(resolve => setTimeout(resolve, ms));

export async function fetchTasks() {
  await wait(3000); // Simulate a delay to trigger the change detection
  const res = await fetch(`${API_URL}/tasks`);
  if (!res.ok) {
    throw new Error(`Failed to fetch tasks: ${res.status}`);
  }
  return await res.json();
}

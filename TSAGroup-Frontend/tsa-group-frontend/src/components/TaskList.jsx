import { useEffect, useState } from "react";
import { fetchTasks } from "../api/tasks";

function TaskList() {
  const [tasks, setTasks] = useState([]);
  const [error, setError] = useState(null);

  useEffect(() => {
    async function loadTasks() {
      try {
        const data = await fetchTasks();
        setTasks(data);
      } catch (err) {
        setError(err.message);
      }
    }
    loadTasks();
  }, []);

  if (error) return <div>Error: {error}</div>;
  if (!tasks.length) return <div>No tasks available</div>;

  return (
    <ul>
      {tasks.map((task) => (
        <li key={task.id}>
          {task.name} {task.description} {task.status} {task.createdAt}{" "}
          {task.updatedAt ?? ""}
        </li>
      ))}
    </ul>
  );
}

export default TaskList;

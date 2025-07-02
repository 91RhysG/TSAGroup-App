import { Suspense, useState, useEffect } from "react";
import { addTask, fetchTasks, updateTask, deleteTask } from "./api/tasks";
import "./App.css";
import TaskList from "./components/TaskList";
import TaskAddDialog from "./components/TaskAddDialog";
import Toast from "./components/Toast";
import { TaskStatusValues } from "./constants/TaskStatus";
const defaultTask = {
  name: "Task Name",
  description: "Task Description",
  status: TaskStatusValues.InProgress,
  createdAt: new Date().toISOString(),
};
const toastTimeout = 2500;

/**
 * Main App component.
 * This component manages the state of tasks, handles adding, updating, and deleting tasks,
 * and displays a list of tasks with a dialog for adding or editing tasks.
 * @returns {JSX.Element} The main App component.
 */
function App() {
  const [dialogOpen, setDialogOpen] = useState(false);
  const [selectedTask, setSelectedTask] = useState(defaultTask);
  const [tasks, setTasks] = useState([]);
  const [existingTask, setExistingTask] = useState(false);
  const [toast, setToast] = useState({ isOpen: false, message: "", backgroundColour: "" });

  useEffect(() => {
    fetchTasks().then(setTasks);
  }, []);

  /**
   * Handles the form submission for adding a new task.
   *
   * @param {Object} task - The task object to add or update.
   */
  const taskHandler = async (task) => {
    if (existingTask) {
      const updatedTask = { ...selectedTask, ...task };
      await updateTask(updatedTask)
        .then((returnedTask) => {
          setTasks((prevTasks) =>
            prevTasks.map((t) => (t.id === returnedTask.id ? returnedTask : t))
          );
          setToast({
            isOpen: true,
            message: "Task updated successfully",
            backgroundColour: "bg-green-500",
          });
          setTimeout(() => setToast({ isOpen: false, message: "", backgroundColour: "" }), 2500);
        })
        .catch((error) => {
          console.error("Failed to update task:", error);
          setToast({
            isOpen: true,
            message: "Failed to update task",
            backgroundColour: "bg-red-500",
          });
          setTimeout(() => setToast({ isOpen: false, message: "", backgroundColour: "" }), 2500);
        });
    } else {
      await addTask(task)
        .then((addedTask) => {
          setTasks((prevTasks) => [...prevTasks, addedTask]);
          setToast({
            isOpen: true,
            message: "Task added successfully",
            backgroundColour: "bg-green-500",
          });
          setTimeout(() => setToast({ isOpen: false, message: "", backgroundColour: "" }), toastTimeout);
        })
        .catch((error) => {
          console.error("Failed to add task:", error);
          setToast({
            isOpen: true,
            message: "Failed to add task",
            backgroundColour: "bg-red-500",
          });
          setTimeout(() => setToast({ isOpen: false, message: "", backgroundColour: "" }), toastTimeout);
        });
    }
  };

  /**
   * Handles the deletion of a task.
   * @param {number} taskId - The ID of the task to delete.
   */
  const deleteTaskHandler = async (taskId) => {
    await deleteTask(taskId)
      .then(() => {
        setTasks((prevTasks) => prevTasks.filter((task) => (task.id ?? task.Id) !== taskId));
        setToast({
          isOpen: true,
          message: "Task deleted successfully",
          backgroundColour: "bg-green-500",
        });
        setTimeout(() => setToast({ isOpen: false, message: "", backgroundColour: "" }), toastTimeout);
      })
      .catch((error) => {
        console.error("Failed to delete task:", error);
        setToast({
          isOpen: true,
          message: "Failed to delete task",
          backgroundColour: "bg-red-500",
        });
        setTimeout(() => setToast({ isOpen: false, message: "", backgroundColour: "" }), toastTimeout);
      });
  };

  return (
    <div className="container mx-auto p-4 bg-white rounded-lg shadow-lg">
      <Toast
        isOpen={toast.isOpen}
        message={toast.message}
        backgroundColour={toast.backgroundColour}
      />
      <div className="text-center mb-6 flex flex-col gap-2">
        <h1>Task List</h1>
        <p>Manage your tasks efficiently</p>
        <p>By Rhys Gillham</p>
        <p>TSA Group Technical</p>
      </div>
      <section className="flex flex-wrap gap-4 p-4">
        <button
          className="!bg-green-500 hover:!bg-green-600 ms-4 text-white font-semibold py-2 px-4 rounded transition-colors"
          onClick={() => {
            setSelectedTask(defaultTask);
            setExistingTask(false);
            setDialogOpen(true);
          }}
        >
          Add Task
        </button>
        <Suspense
          fallback={
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512">
              Loading ...
              <path d="M304 48a48 48 0 1 0 -96 0 48 48 0 1 0 96 0zm0 416a48 48 0 1 0 -96 0 48 48 0 1 0 96 0zM48 304a48 48 0 1 0 0-96 48 48 0 1 0 0 96zm464-48a48 48 0 1 0 -96 0 48 48 0 1 0 96 0zM142.9 437A48 48 0 1 0 75 369.1 48 48 0 1 0 142.9 437zm0-294.2A48 48 0 1 0 75 75a48 48 0 1 0 67.9 67.9zM369.1 437A48 48 0 1 0 437 369.1 48 48 0 1 0 369.1 437z" />
            </svg>
          }
        >
          <TaskList
            tasks={tasks}
            onTaskSelect={(task) => {
              setExistingTask(true);
              setSelectedTask(task);
              setDialogOpen(true);
            }}
          />
        </Suspense>
      </section>
      <TaskAddDialog
        open={dialogOpen}
        onClose={() => {
          setDialogOpen(false);
        }}
        onSubmit={taskHandler}
        task={selectedTask}
        existingTask={existingTask}
        deleteTask={deleteTaskHandler}
      />
    </div>
  );
}

export default App;

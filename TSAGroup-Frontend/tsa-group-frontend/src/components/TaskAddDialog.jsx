import { TaskStatusValues, TaskStatusLabels } from "../constants/TaskStatus";
import { toDatetimeLocal } from "../helpers/date";
/**
 * TaskAddDialog component displays a dialog for adding a new task.
 *
 * @param {Object} param0 - The props object.
 * @param {boolean} param0.open - Indicates if the dialog is open.
 * @param {Function} param0.onClose - The function to call when the dialog is closed.
 * @returns {JSX.Element|null} The rendered dialog component or null if closed.
 */
function TaskAddDialog({
  open,
  onClose,
  onSubmit,
  task,
  existingTask,
  deleteTask,
}) {
  if (!open) return null;

  /**
   * Handles the form submission for adding a new task.
   *
   * @param {Event} event - The submit event.
   */
  const handleSubmit = (event) => {
    event.preventDefault();
    const formData = new FormData(event.target);
    const createdAtValue = formData.get("createdAt");
    const newTask = {
      Name: formData.get("name"),
      Description: formData.get("description"),
      CreatedAt: createdAtValue
        ? new Date(createdAtValue).toISOString()
        : new Date().toISOString(),
      Status: TaskStatusValues.NotStarted,
    };
    onSubmit(newTask);
    onClose();
  };

  return (
    <div
      className={`fixed inset-0 bg-black bg-opacity-50 z-50 ${
        open ? "flex" : "hidden"
      } items-center justify-center`}
      onClick={onClose}
    >
      <div
        className="bg-white rounded-lg p-4 shadow-lg"
        onClick={(e) => e.stopPropagation()}
      >
        <h2 className="text-lg font-semibold mb-4">Add New Task</h2>
        <form onSubmit={handleSubmit}>
          <label htmlFor="name">Task Name</label>
          <input
            type="text"
            name="name"
            placeholder={task.name ?? "Task Name"}
            defaultValue={existingTask ? task.name : ""}
            className="border p-2 w-full mb-4"
            required
          />
          <label htmlFor="description">Description</label>
          <textarea
            placeholder={task.description ?? "Task Description"}
            defaultValue={existingTask ? task.description : ""}
            name="description"
            className="border p-2 w-full mb-4"
            required
          ></textarea>
          <label htmlFor="status">Status</label>
          <select
            name="status"
            className="border p-2 w-full mb-4"
            defaultValue={task.status ?? TaskStatusValues.NotStarted}
            required
          >
            {Object.entries(TaskStatusLabels).map(([value, label]) => (
              <option key={value} value={value}>
                {label}
              </option>
            ))}
          </select>
          <div>
            <label htmlFor="createdAt">Created At</label>
            <input
              type="datetime-local"
              name="createdAt"
              className="border p-2 w-full mb-4"
              readOnly
              defaultValue={
                existingTask
                  ? toDatetimeLocal(task.createdAt) ?? new Date().toISOString()
                  : toDatetimeLocal(new Date().toISOString())
              }
              required
            />
          </div>
          {task.updatedAt && (
            <div>
              <label htmlFor="updatedAt">Updated At</label>
              <input
                type="datetime-local"
                name="updatedAt"
                className="border p-2 w-full mb-4"
                readonly
                defaultValue={
                  toDatetimeLocal(task.updatedAt) ?? new Date().toISOString()
                }
              />
            </div>
          )}
          <div className="flex justify-end">
            <button
              type="button"
              className="!bg-gray-300 !hover:bg-gray-400 text-black font-semibold py-2 px-4 rounded mr-2"
              onClick={onClose}
            >
              Cancel
            </button>
            {existingTask && deleteTask && (
              <button
                type="button"
                className="!bg-red-500 !hover:bg-red-600 text-white font-semibold py-2 px-4 rounded mr-2"
                onClick={() => {
                  deleteTask(task.id);
                  onClose();
                }}
              >
                Delete Task
              </button>
            )}
            <button
              type="submit"
              className="!bg-blue-500 !hover:bg-blue-600 text-white font-semibold py-2 px-4 rounded"
            >
              {existingTask ? "Update Task" : "Add Task"}
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}

export default TaskAddDialog;

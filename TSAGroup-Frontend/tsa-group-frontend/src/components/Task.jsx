import { TaskStatusLabels } from "../constants/TaskStatus";
import { toDatetimeLocal } from "../helpers/date";

/**
 * Task component displays a single task item.
 *
 * @param {Object} param0 - The props object.
 * @param {Object} param0.task - The task object to display.
 * @param {Function} param0.onClick - The click handler function.
 * @returns {JSX.Element} The rendered task component.
 */
function Task({ task, onClick }) {
  return (
    <div key={task.id} className="border-2 border-purple-500 bg-purple-200 hover:bg-purple-950 hover:text-white w-50 h-50 overflow-auto p-4 rounded-md" onClick={onClick}>
      <div>{task.name}</div>
      <div>{task.description}</div>
      <div>{TaskStatusLabels[task.status]}</div>
      <div>{toDatetimeLocal(task.createdAt)}</div>
      <div>{toDatetimeLocal(task.updatedAt) ?? ""}</div>
    </div>
  );
}

export default Task;

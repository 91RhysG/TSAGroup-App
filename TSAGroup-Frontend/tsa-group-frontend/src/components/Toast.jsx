/**
 * Toast component displays a notification message.
 *
 * @param {Object} param0 - The props object.
 * @param {boolean} param0.isOpen - Indicates if the toast is open.
 * @param {string} param0.message - The message to display in the toast.
 * @param {string} param0.backgroundColour - The background color class for the toast.
 * @returns {JSX.Element} The rendered toast component.
 */
function Toast({ isOpen, message, backgroundColour }) {
  return (
    <div
      className={`${
        isOpen ? "show" : "hidden"
      } toast fixed top-6 right-6 ${backgroundColour} text-white px-6 py-3 rounded-lg shadow-lg z-50 transition-all`}
    >
      <div className="toast-content">{message}</div>
    </div>
  );
}

export default Toast;

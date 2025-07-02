/**
 * Converts a date string to a datetime-local format.
 *
 * @param {string} dateString - The date string to convert.
 * @returns {string} The converted datetime-local string.
 */
export function toDatetimeLocal(dateString) {
  if (!dateString) return "";
  const date = new Date(dateString);
  const pad = (n) => n.toString().padStart(2, "0");
  return (
    date.getFullYear() +
    "-" +
    pad(date.getMonth() + 1) +
    "-" +
    pad(date.getDate()) +
    "T" +
    pad(date.getHours()) +
    ":" +
    pad(date.getMinutes())
  );
}
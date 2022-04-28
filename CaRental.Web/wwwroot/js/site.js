function formatDateTimeForInput(date) {
    let years = date.getFullYear();
    let months = ("0" + (date.getMonth() + 1)).slice(-2);
    let days = ("0" + date.getDate()).slice(-2);
    let hours = ("0" + date.getHours()).slice(-2);
    let minutes = ("0" + date.getMinutes()).slice(-2);

    return `${years}-${months}-${days}T${hours}:${minutes}`;
}
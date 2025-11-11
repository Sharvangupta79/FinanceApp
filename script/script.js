const items = [
  "Apple", "Banana", "Orange", "Grapes", "Pineapple",
  "Mango", "Strawberry", "Blueberry", "Watermelon", "Kiwi"
];

const searchInput = document.getElementById("searchInput");
const suggestions = document.getElementById("suggestions");
const resultsList = document.getElementById("resultsList");
const searchBtn = document.getElementById("searchBtn");

// Show suggestions as user types
searchInput.addEventListener("input", () => {
  const query = searchInput.value.toLowerCase();
  suggestions.innerHTML = "";

  if (query) {
    const filtered = items.filter(item => item.toLowerCase().includes(query));
    filtered.forEach(item => {
      const li = document.createElement("li");
      li.textContent = item;
      li.addEventListener("click", () => {
        searchInput.value = item;
        suggestions.innerHTML = "";
      });
      suggestions.appendChild(li);
    });
  }
});

// Filter results on search button click
searchBtn.addEventListener("click", () => {
  const query = searchInput.value.toLowerCase();
  resultsList.innerHTML = "";

  const filtered = items.filter(item => item.toLowerCase().includes(query));
  if (filtered.length === 0) {
    resultsList.innerHTML = "<li>No results found.</li>";
  } else {
    filtered.forEach(item => {
      const li = document.createElement("li");
      li.textContent = item;
      resultsList.appendChild(li);
    });
  }
});
const burgerBtn = document.querySelector(".menu-burger-btn");
const burgerMenu = document.querySelector(".menu-burger");

burgerBtn.addEventListener("click", () => {
  burgerMenu.classList.toggle("d-none");
});

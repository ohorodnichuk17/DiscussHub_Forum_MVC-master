const signUpBtn = document.getElementById("signUp");
const signInBtn = document.getElementById("signIn");
const container = document.querySelector(".containerr");

signUpBtn.addEventListener("click", () => {
    container.classList.add("right-panel-active");
});
signInBtn.addEventListener("click", () => {
    container.classList.remove("right-panel-active");
});


//function redirectToSignUpFormPage() {
//    window.location.href = '/SignInSignUpForm/SignUpForm';
//}
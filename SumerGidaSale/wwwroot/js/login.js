//Þifre
document.addEventListener("DOMContentLoaded", function () {
    var passwordInput = document.getElementById("password");
    var showPassCheckbox = document.getElementById("showPass");

    showPassCheckbox.addEventListener("change", function () {
        if (showPassCheckbox.checked) {
            passwordInput.type = "text"; // Þifreyi göster
        } else {
            passwordInput.type = "password"; // Þifreyi gizle
        }
    });
});
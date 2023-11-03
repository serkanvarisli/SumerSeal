
document.addEventListener("DOMContentLoaded", function () {
    var passwordInput = document.getElementById("password");
    var showPassCheckbox = document.getElementById("showPass");

    showPassCheckbox.addEventListener("change", function () {
        if (showPassCheckbox.checked) {
            passwordInput.type = "text"; // Şifreyi göster
        } else {
            passwordInput.type = "password"; // Şifreyi gizle
        }
    });
});

//Satış Yapma Formu
function showSaleForm() {
    var saleForm = document.getElementById("saleForm");
    if (saleForm.style.display === "none" || saleForm.style.display === "") {
        saleForm.style.display = "block";
    } else {
        saleForm.style.display = "none";
    }
}
//Kapat
function closeSaleForm() {
    var saleForm = document.getElementById("saleForm");
    saleForm.style.display = "none";
}

//modal
function openModal() {
    var myModal = document.getElementById("myModal");
    var closeModal = document.getElementById("closeModalBtn")
    var openModal = document.getElementById("openModalBtn")
    if (myModal.style.display === "none") {
        myModal.style.display = "block";
        closeModal.style.display = "block";
        openModal.style.display = "none";
    } else {
        myModal.style.display = "none";
    }
}

function closeModal() {
    var myModal = document.getElementById("myModal");
    var closeModal = document.getElementById("closeModalBtn")
    var openModal = document.getElementById("openModalBtn")
    myModal.style.display = "none";
    closeModal.style.display = "none";
    openModal.style.display = "block";

}




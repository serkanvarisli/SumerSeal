

// Satış form jquery
$(document).ready(function () {
    $(".open-sale-form").click(function () {
        var saleForm = $(this).closest("tr").find(".sale-form");
        saleForm.show();
    });

    $(".close-sale-form").click(function () {
        var saleForm = $(this).closest(".sale-form");
        saleForm.hide();
    });
});


//Ekleme Formu
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




window.addEventListener("load", solve);

function solve() {
    let roomSizeInput = document.getElementById('room-size');
    let timeSlotInput = document.getElementById('time-slot');
    let fullNameInput = document.getElementById('full-name');
    let emailInput = document.getElementById('email');
    let phoneNumberInput = document.getElementById('phone-number');

    let bookRoomButton = document.getElementById('book-btn');
    let bookPreviewElement = document.getElementById('preview');

    let previewRoomSize = document.getElementById('preview-room-size');
    let previewTimeSlot = document.getElementById('preview-time-slot');
    let previewFullName = document.getElementById('preview-full-name');
    let previewEmail = document.getElementById('preview-email');
    let previewPhoneNumber = document.getElementById('preview-phone-number');

    bookRoomButton.addEventListener("click", onBook);

    function onBook(){
        if(roomSizeInput.value<=0 || timeSlotInput.value =="" || fullNameInput.value=="" || emailInput.value=="" || phoneNumberInput.value==""){
            return;
        }
        bookPreviewElement.style.display="block";
        previewRoomSize.textContent = roomSizeInput.value;
        previewTimeSlot.textContent = timeSlotInput.value;
        previewFullName.textContent = fullNameInput.value;
        previewEmail.textContent = emailInput.value;
        previewPhoneNumber.textContent = phoneNumberInput.value;

        bookRoomButton.disabled = true;     
        roomSizeInput.value = "";
        timeSlotInput.value = "";
        fullNameInput.value = "";
        emailInput.value = "";
        phoneNumberInput.value = "";
    }

    let editButton = document.getElementById('edit-btn');
    editButton.addEventListener("click", onEdit)

    function onEdit(){
        roomSizeInput.value = previewRoomSize.textContent;
        timeSlotInput.value = previewTimeSlot.textContent;
        fullNameInput.value = previewFullName.textContent;
        emailInput.value = previewEmail.textContent;
        phoneNumberInput.value = previewPhoneNumber.textContent;

        bookRoomButton.disabled = false; 
        bookPreviewElement.style.display="none"; 
    }

    let confirmButton = document.getElementById('confirm-btn');
    let confirmElemen = document.getElementById('confirmation');

    confirmButton.addEventListener("click", onConfirm);

    function onConfirm(){
        bookPreviewElement.style.display="none"; 
        confirmElemen.style.display = "block";
    }

    let backButton = document.getElementById('back-btn');
    backButton.addEventListener("click", onBack);

    function onBack(){
        confirmElemen.style.display = "none";
        bookRoomButton.disabled = false; 
    }    
}
  
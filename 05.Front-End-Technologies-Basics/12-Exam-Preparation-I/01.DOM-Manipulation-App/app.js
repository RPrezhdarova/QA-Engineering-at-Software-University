window.addEventListener("load", solve);

function solve() {
    let numberOfTicketsInput = document.getElementById('num-tickets');
    let seatingPreferenceInput = document.getElementById('seating-preference');
    let fullNameInput = document.getElementById('full-name');
    let emailInput = document.getElementById('email');
    let phoneNumberInput = document.getElementById('phone-number');

    let purchaseTicketsNumber = document.getElementById('purchase-num-tickets');
    let purchaseSeatingPreference = document.getElementById('purchase-seating-preference');
    let purchaseFullName = document.getElementById('purchase-full-name');
    let purchaseEmail = document.getElementById('purchase-email');
    let purchasePhoneNumber = document.getElementById('purchase-phone-number');

    let purchaseTicketButton = document.getElementById('purchase-btn');    
    let ticketPreviewElement = document.getElementById('ticket-preview');

//proverka v konzolata dali sme napravili poletata pravilno

    //purchaseTicketButton.addEventListener("click", printValues);

    // function printValues(){
    //     console.log(numberOfTicketsInput.value);
    //     console.log(seatingPreferenceInput.value);
    //     console.log(emailInput.value);
    //     console.log(fullNameInput.value);
    //     console.log(phoneNumberInput.value);
    // }

    purchaseTicketButton.addEventListener("click", previewTickets)

    function previewTickets(){
        if(Number(numberOfTicketsInput.value) <=0 || seatingPreferenceInput.value == 'seating-preference' || fullNameInput.value == '' || emailInput.value == ''||phoneNumberInput.value==''){
            return;
        }
        //Display the ticket info in the hidden element
        ticketPreviewElement.style.display="block";
        purchaseTicketsNumber.textContent = numberOfTicketsInput.value;
        purchaseSeatingPreference.textContent = seatingPreferenceInput.value;
        purchaseFullName.textContent = fullNameInput.value;
        purchaseEmail.textContent = emailInput.value;
        purchasePhoneNumber.textContent = phoneNumberInput.value;

        //Disable purchase ticket button
        purchaseTicketButton.disabled = true;

        //Clear the values of the input fields
        numberOfTicketsInput.value = "";
        seatingPreferenceInput.value = "seating-preference";
        fullNameInput.value = "";
        emailInput.value = "";
        phoneNumberInput.value ="";
    }
        //Edit Ticket Info

    let editButton = document.getElementById('edit-btn');
    editButton.addEventListener("click", onEdit)

    function onEdit(){
        numberOfTicketsInput.value = purchaseTicketsNumber.textContent;
        seatingPreferenceInput.value = purchaseSeatingPreference.textContent;
        fullNameInput.value = purchaseFullName.textContent;
        emailInput.value = purchaseEmail.textContent;
        phoneNumberInput.value = purchasePhoneNumber.textContent;

        purchaseTicketButton.disabled = false;
        ticketPreviewElement.style.display="none";
    }

    //Buy ticket

    let buyButton = document.getElementById('buy-btn')
    let purchaseSuccsessElement = document.getElementById('purchase-success')
    buyButton.addEventListener("click", onBuy)

    function onBuy(){
        ticketPreviewElement.style.display="none";
        purchaseSuccsessElement.style.display = "block";
    }
  
    //Back

    let backButton = document.getElementById('back-btn');
    backButton.addEventListener("click", onBack)

    function onBack(){
        purchaseSuccsessElement.style.display = "none";
        purchaseTicketButton.disabled = false;
    }

}
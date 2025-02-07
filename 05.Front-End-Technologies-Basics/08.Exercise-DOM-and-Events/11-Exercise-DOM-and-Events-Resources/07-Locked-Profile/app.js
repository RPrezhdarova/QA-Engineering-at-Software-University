function lockedProfile() {
    let buttons = document.getElementsByTagName("button");
    for (const button of buttons) {
        button.addEventListener('click', showInfo);      
    }
    function showInfo(event){
        let lockRadioButton = event.target.parentNode.children[2];

        let hiddenDivElement = event.target.previousElementSibling;

        if(lockRadioButton.checked == false){
            if(event.target.textContent == "Hide it"){
                hiddenDivElement.style.display = "none";
                event.target.textContent = "Show more";
            }
            else{
                hiddenDivElement.style.display = "block";
                event.target.textContent = "Hide it";
            }
            
        }
    }
}

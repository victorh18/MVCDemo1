function deleteDivById(id){
    var element = document.getElementById(id);
    element.parentNode.removeChild(element);
}

//Function to add the checkboxes as the user selects them
function addAuthor() {
    //We get the selected list
    var selList = document.getElementById('Autores');
    //Then we capture the values of the fields in variables for easier use
    var intValue = selList.options[selList.selectedIndex].value;
    var authorName = selList.options[selList.selectedIndex].text;



    //Then, we create the checkbox element with the previous values extracted from the select list
    var authorItem = document.createElement('input');
    var authorLabel = document.createElement('label');

    //Adding the button to erase it
    var deleteButton = document.createElement('button');
    authorLabel.appendChild(deleteButton);
    deleteButton.setAttribute('type', 'button');
    deleteButton.setAttribute('class', 'btn btn-danger');
    deleteButton.setAttribute('onclick', 'deleteAuthor(this)')
    //See how many authors where added so I can assign an ID
    var nodes = deleteButton.parentElement.childNodes[0];
    var l = nodes.value;
    deleteButton.setAttribute('id', l);
    deleteButton.innerHTML = 'BORRAR';

    authorItem.setAttribute('type', 'hidden');
    authorItem.setAttribute('value', String(intValue));
    //authorItem.setAttribute('disabled', 'disabled');
    authorItem.setAttribute('checked', 'checked');
    authorItem.setAttribute('name', 'selectedAuthors')
    authorLabel.appendChild(authorItem);
    authorLabel.innerHTML = authorLabel.innerHTML + authorName;



    

    //Adding the element to the corresponding place in the form
    var divAuthors = document.getElementById('lstAutores');
    var tempDiv = document.createElement('div');
    tempDiv.appendChild(authorLabel);
    tempDiv.appendChild(document.createElement('br'));
    divAuthors.appendChild(tempDiv);
    //divAuthors.appendChild(document.createElement('br'));

    selList.selectedIndex = 0;
}

function deleteAuthor(button) {
    var lstAuthors = document.getElementById('lstAutores');
    //lstAuthors.parentNode.removeChild(button.parentNode);
    lstAuthors.removeChild(button.parentNode.parentNode);
}

document.getElementById('btnAgregarAutor').onclick = function () {
    addAuthor();
}

//document.getElementsByClassName('btn').onclick = function (this) {
//    deleteAuthor(this);
//}
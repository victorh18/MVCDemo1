function deleteDivById(id){
    var element = document.getElementById(id);
    element.parentNode.removeChild(element);
}
function loadTestsData(){
    var data;
    $.ajax({
        //url: 'https://api.myjson.com/bins/gato7',
        url: 'tests.json',
        dataType: 'json',
        type: 'get',
        cache: 'false',
        async: 'false',
        success: function(data){
           handleData(data);
        },
        error: function(XMLHttpRequest, textStatus, errorThrown) { 
            console.log("Status: " + textStatus); alert("Error: " + errorThrown); 
        }   
    });
}

function handleData(data){

    $( document ).ready(function() {
        $(data.tests).each((index, value)=>{
            $("#tests-list").append($('<li>').html('<a href="#" id="'+value.id+"-test"+'">'+value.name+'</a>'));
            $("#"+value.id+"-test").click(()=>{
                populateAndOpenModal(value);
            })
        });
    });

   
}

function populateAndOpenModal(value){
    $("#test-name").text(value.name);
    $("#test-decription").text(value.description);
    $("#test-media-hiperlinks").text(value.media);
    $("#test-media-hiperlinks").attr("href", value.media);
    $("#modal-test").modal('toggle');
}
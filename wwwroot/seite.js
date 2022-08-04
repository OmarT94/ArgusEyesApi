const uri = 'api/MetaDaten';
/*let todos = [];*/

//function getItems() {
//    fetch(uri)
//        .then(response => response.json())
//        .then(data => _displayKundenDaten(data))
//        .catch(error => console.error('Unable to get items.', error));
//}




function addMetaHelligkeit() {

    // Hole mir das Element für die Helligkeit 
    const helligkeit = document.getElementById('myRange1');
    const kontrast = document.getElementById('myRange2');

    const itemH = {
        Id: 2,
        HelligkeitDto: helligkeit.value.trim(),
        KontrastDto: kontrast.value.trim()
        //XDto: 0,
        //YDto: 0,
        //TextDto: "",
        //ImageId:0
       
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type':'application/json'
        },
        body: JSON.stringify(itemH)
    })
        .then(response => response.json())
        .then(() => {
            /* getItems();*/
            helligkeit.value = response.HelligkeitDto;
            kontrast.value = response.KontrastDto
        })
        .catch(error => console.error('Unable to add item.', error));
}
////////////////////////////////////////////////////////////////////////////////




function addMetaKontrast() {
    const kontrast = document.getElementById('myRange2');
    const helligkeit = document.getElementById('myRange1');
    

    const dto = {
        Id: 2,
        KontrastDto: kontrast.value.trim(),
        HelligkeitDto: helligkeit.value.trim()
       
      
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(dto)
    })
        .then(response => response.json())
        .then(() => {
            
            helligkeit.value = response.HelligkeitDto;
            kontrast.value = response.KontrastDto;
        })
        .catch(error => console.error('Unable to add item.', error));
}

/////////////////////////////////////////////////////////////////////////


var urii = 'api/KundenImages';
function addImage() {
    var nameElement = document.getElementById('name');
    var imagePathElement = document.getElementById('image');


    var dto = {
        Name: nameElement.value.trim(),
        ImagePath: imagePathElement.value.trim()
    };

    fetch(urii, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(dto)
    })
        .then(response => response.json())
        .then(() => {

            nameElement.value = response.Name;
            imagePathElement.value = response.ImagePath;
        })
        .catch(error => console.error('Unable to add item.', error));
}

///////////////////////////////////////////////////////////////////////


async function SucheImage() {
    var imageIdElement = document.getElementById('imageId');
    var id = imageIdElement.value;
    var myImage = document.getElementById('resultImage');

    myRequest = new Request('https://localhost:7133/api/KundenImages/' + id);

    fetch(myRequest)
        .then(function (response) {
            console.log(response.json)
            return response.json();
        }).then((data) => {
            console.log(data);
            myImage.src = "data:image/png; base64, " + data.contentFile;
           /* myImage.src = data.HelligkeitDto;*/
            console.log(data.contentFile)
        })
         .catch(error => console.error('Unable to add item.', error));
    //console.log("before fetch")
    //await fetch('https://localhost:7133/api/KundenImages/' + id, {
    //    method: 'GET',
    //    //headers: {
    //    //    'Accept': 'application/json',
    //    //    'Content-Type': 'application/json'
    //    //},
    //})


    //    .then((response) => { console.log(response); response.json() })
    //    .then((data) => {
    //        console.log(data);
    //        myImage.src = "data:image/png; base64, " + data.ContentFile;
    //    })
    //    .catch(error => console.error('Unable to add item.', error));
   
}

///////////////////////////////////////////////////////////////////////////////

//async function GetImageMetaDaten() {
//    var imageIdElement = document.getElementById('imageId');
//    var id = imageIdElement.value;
//    var myImage = document.getElementById('resultImage');

//    myRequest = new Request('https://localhost:7133/api/MetaDaten/' + id);

//    fetch(myRequest)
//        .then(function (response) {
//            console.log(response.json)
//            return response.json();
//        }).then((data) => {
//            console.log(data);
//            myImage.src = "data:image/png; base64, " + data.contentFile;
//            console.log(data.contentFile)
//        })
//        .catch(error => console.error('Unable to add item.', error));

//}



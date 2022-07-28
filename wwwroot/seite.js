const uri = 'api/MetaDaten';
/*let todos = [];*/

function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayKundenDaten(data))
        .catch(error => console.error('Unable to get items.', error));
}




function addMetaHelligkeit() {
    const addMetaDataH = document.getElementById('myRange1');

    const itemH = {
        Id: 2,
        HelligkeitDto: addMetaDataH.value.trim()
       /* KontrastDto:0*/ /*addMetaData.value.trim()*/
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
            addMetaDataH.value = '';
        })
        .catch(error => console.error('Unable to add item.', error));
}

function addMetaKontrast() {
    const addMetaData = document.getElementById('myRange2');

    const item = {
        Id: 49,
        KontrastDto: addMetaData.value.trim()
      
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(() => {
            
            addMetaData.value = '';
        })
        .catch(error => console.error('Unable to add item.', error));
}
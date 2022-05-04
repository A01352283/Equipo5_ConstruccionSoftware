/*
Percussion Islands 
May 2022
Salvador Salgado Normandia
*/

//This script is used to access, insert, update or delete information from the table game_user_key_inventory
function main()
{   //obtain all the records in game_user_key_inventory and shows them in a table
    formSelect.onsubmit = async (e) =>{
        e.preventDefault()

        let response = await fetch('http://localhost:5000/api/game_user/key_inventory',{
            method: 'GET'
        })
        
        if(response.ok)
        {
            let results = await response.json()
        
            const headers = Object.keys(results[0])
            const values = Object.values(results)

            let table = document.createElement("table")

            let tr = table.insertRow(-1)                  

            for(const header of headers)
            {
                let th = document.createElement("th")     
                th.innerHTML = header
                tr.appendChild(th)
            }

            for(const row of values)
            {
                let tr = table.insertRow(-1)

                for(const key of Object.keys(row))
                {
                    let tabCell = tr.insertCell(-1)
                    tabCell.innerHTML = row[key]
                }
            }

            const container = document.getElementById('getResults')
            container.innerHTML = ''
            container.appendChild(table)
        }
        else{
            getResults.innerHTML = response.status
        }
    }
    //obtains the new game_user_key_inventory info from the html input and calls the api to insert the new record
    formInsert.onsubmit = async(e)=>
    {
        e.preventDefault()

        const data = new FormData(formInsert)
        const dataObj = Object.fromEntries(data.entries())
        // let data = {}
        // console.log(formInsert.elements['firstName'].value)

        // const test = new FormData(formInsert).entries()

        // console.log(test)
        // for(let [key, value] of test)
        //     data[key] = value
        // console.log(JSON.stringify(data))

        let response = await fetch('http://localhost:5000/api/game_user/key_inventory',{
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(dataObj)
        })
        
        if(response.ok)
        {
            let results = await response.json()
        
            console.log(results)
            postResults.innerHTML = results.message
        }
        else{
            postResults.innerHTML = response.status
        }
    }
    //obtains the game user key inventory info from the html input and calls the api to update the record
    formUpdate.onsubmit = async(e)=>
    {
        e.preventDefault()

        const data = new FormData(formUpdate)
        const dataObj = Object.fromEntries(data.entries())

        let response = await fetch('http://localhost:5000/api/game_user/key_inventory',{
            method: 'PUT',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(dataObj)
        })
        
        if(response.ok)
        {
            let results = await response.json()
        
            console.log(results)
            putResults.innerHTML = results.message
        }
        else{
            putResults.innerHTML = response.status
        }
    }
    //obtains the user_id from the html input and calls the api to delete the key_inventory record with that key identification
    formDelete.onsubmit = async(e)=>
    {
        e.preventDefault()

        const data = new FormData(formDelete)
        const dataObj = Object.fromEntries(data.entries())

        let response = await fetch('http://localhost:5000/api/game_user/key_inventory',{
            method: 'DELETE',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(dataObj)
        })
        
        if(response.ok)
        {
            let results = await response.json()
        
            console.log(results)
            deleteResults.innerHTML = results.message
        }
        else{
            deleteResults.innerHTML = response.status
        }
    }
}

main()
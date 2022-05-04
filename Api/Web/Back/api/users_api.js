/*
User_api.js
Percussion Islands 
May 2022
Salvador Salgado Normandia
*/


"use strict"
import express, { response } from 'express'
import mysql from 'mysql'
import fs from 'fs'
import { request } from 'http';

const app = express();
const port = 5000;

app.use(express.json());

//Format read
app.use('/scripts/charts', express.static('./node_modules/chart.js/dist/'))
app.use('/js', express.static('./js'))
app.use('/css', express.static('./css'))
app.use('/fonts', express.static('./fonts'))
app.use('/files',express.static('./files'))

//This function allows access to the Scheme in MySql
function connectToDB()
{
    try{
        //Obtain this info by create a user in MySql within the privileges section to modify percussion_island3
        return mysql.createConnection({host:'localhost', 
        user:'final_admin', 
        password:'Destiny2', 
        database: 'percussion_island3'});
    }
    catch(error)
    {
        console.log(error);
    }   
}

//This api call obtains the main web-page site.
app.get('/', (request,response)=>{
    fs.readFile('./html/webpage.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err);
        console.log('Loading page...');
        response.send(html);
    })
});

app.get('/rankings', (request,response)=>{
    fs.readFile('./html/rankings.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err);
        console.log('Loading page...');
        response.send(html);
    })
});

/*
//This api call obtains the web-page of all the users
app.get('/game_user', (request,response)=>{
    fs.readFile('./html/gameUsers.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err);
        console.log('Loading page...');
        response.send(html);
    })
});
*/

/*
//This api call obtains the web-page of the scores from the users
app.get('/game_user/scores', (request,response)=>{
    fs.readFile('./html/userScores.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err);
        console.log("Loading page...");
        response.send(html)
    })
});
*/

/*
//This api call obtains the web-page of the questions
app.get('/questions', (request,response)=>{
    fs.readFile('./html/questions.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err);
        console.log("Loading page...");
        response.send(html)
    })
});
*/

//This api call verifies if a specific user_name and password exists in the database (if true return 1)
app.post('/api/game_user/verify', (request,response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('SELECT COUNT(1) from game_user where user_name=? and pwd=?', [request.body['user_name'], request.body['pwd']], (error, results, fields)=>{
            if(error) console.log(error);
            response.json(results[0]["COUNT(1)"]);
        });

        connection.end();

    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});

//This api call obtains all the users from game_user table
app.get('/api/game_user', (request, response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('select * from game_user', (error, results, fields)=>{
            if(error) console.log(error);
            response.json(results);
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});

//This api call obtains all the game_user_scores
app.get('/api/game_user/scores', (request, response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('select * from game_user_scores', (error, results, fields)=>{
            if(error) console.log(error);
            response.json(results);
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});


//This api call obtains all the values from game_user_key_inventory
app.get('/api/game_user/key_inventory', (request,response)=>{
    let connection = connectToDB();
    try{

        connection.connect();

        connection.query('select * from game_user_key_inventory', (error, results, fields)=>{
            if(error) console.log(error);
            response.json(results);
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});

//This api call obtains all the values from the game_user_save_file
app.get('/api/game_user/sf', (request,response)=>{
    let connection = connectToDB();
    try{

        connection.connect();

        connection.query('select * from game_user_save_file', (error, results, fields)=>{
            if(error) console.log(error);
            response.json(results);
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});

//This api call obtains all the quesions (including the correct and incorrect answers)
app.get('/api/questions', (request, response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('select * from questions', (error, results, fields)=>{
            if(error) console.log(error);
            response.json(results);
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});

//This API call obtains the information stored in the view top_rhythm_scores, which contains the top 10 users with best score in the rhythm minigame
app.get('/api/top-scores/rhythm', (request, response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('select * from top_rhythm_scores', (error, results, fields)=>{
            if(error) console.log(error);
            response.json(results);
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }

});

//This API call obtains the information stored in the view top_trivia_scores, which contains the top 10 users with best score in the trivia minigame
app.get('/api/top-scores/trivia', (request, response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('select * from top_trivia_scores', (error, results, fields)=>{
            if(error) console.log(error);
            response.json(results);
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }

});

//This API call obtains the information stored in the view top_memory_scores, which contains the top 10 users with best score in the memory minigame
app.get('/api/top-scores/memory', (request, response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('select * from top_memory_scores', (error, results, fields)=>{
            if(error) console.log(error);
            response.json(results);
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }

});

//This API call obtains the information stored in the view top_memorysounds_scores, which contains the top 10 users with best score in the memorysounds minigame
app.get('/api/top-scores/memorysounds', (request, response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('select * from top_memorysounds_scores', (error, results, fields)=>{
            if(error) console.log(error);
            response.json(results);
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }

});

//This api call returns the data from the view total_play_time, which contains the sum of the play time from each user in every minigame in seconds
app.get('/api/total_play_time', (request, response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('select * from total_play_time', (error, results, fields)=>{
            if(error) console.log(error);
            response.json(results);
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }

});


//This api call inserts a new user into the table game_user.  It is importatn to consider that the schema created for this proyecto contains triggers that automatically creates the records of the rest of the tables which contain the foreign key of user_id with default values.
app.post('/api/game_user', (request, response)=>{

    try{
        console.log(request.headers);

        let connection = connectToDB();
        connection.connect();

        const query = connection.query('insert into game_user set ?', request.body ,(error, results, fields)=>{
            if(error) 
                console.log(error);
            else
                response.json({'message': "User Created Succesfully!"})
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});

//This api call inserts a new user_score record into the table game_user_scores
app.post('/api/game_user/scores', (request, response)=>{

    try{
        console.log(request.headers);

        let connection = connectToDB();
        connection.connect();

        const query = connection.query('insert into game_user_scores set ?', request.body ,(error, results, fields)=>{
            if(error) 
                console.log(error);
            else
                response.json({'message': "Data inserted correctly."})
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});

//This api call inserts a new user_key_inventory record into the table game_user_key_inventory
app.post('/api/game_user/key_inventory', (request, response)=>{

    try{
        console.log(request.headers);

        let connection = connectToDB();
        connection.connect();

        const query = connection.query('insert into game_user_key_inventory set ?', request.body ,(error, results, fields)=>{
            if(error) 
                console.log(error);
            else
                response.json({'message': "Data inserted correctly."})
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});

//This api call inserts a new user_sf (save-file) record into the table game_user_save_file
app.post('/api/game_user/sf', (request, response)=>{

    try{
        console.log(request.headers);

        let connection = connectToDB();
        connection.connect();

        const query = connection.query('insert into game_user_save_file set ?', request.body ,(error, results, fields)=>{
            if(error) 
                console.log(error);
            else
                response.json({'message': "New user created correctly! Returning to Login Screen...."})
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});

//This api call inserts a new question record into the table questions
app.post('/api/questions', (request, response)=>{

    try{
        console.log(request.headers);

        let connection = connectToDB();
        connection.connect();

        const query = connection.query('insert into questions set ?', request.body ,(error, results, fields)=>{
            if(error) 
                console.log(error);
            else
                response.json({'message': "Question inserted correctly."})
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});

//This API call uses a store procedure get_user_id, which recieves a user_name and return its user_id value *only the number itself
app.post('/api/game_user/id', (request, response)=>{
    try{
        let connection = connectToDB();
        connection.connect();
        const query = connection.query('CALL get_user_id(?)', [request.body['user_name']] ,(error, results, fields)=>{
            if(error) 
                console.log(error);
            else
                //Extracts the user_id from the json results
                response.json(results[0][0]["user_id"]);
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});

//This api call updates the information of a user record inside the table game_user
app.put('/api/game_user', (request, response)=>{
    try{
        let connection = connectToDB();
        connection.connect();
        //When using an update query it is important to follow the correct format (name of coulmns and key identificator). When sending the data it is importat to extract the user_id in order to insert the values correctly
        //Create data without user_id and its values
        const data = Object.entries(request.body).filter(([k,v])=> k!='user_id');
        //Create queryData in order to send the data when doing the query
        const queryData = Object.fromEntries(data);
        //When doing the query we must send a list containing the new data as well as the user_id from the original request
        const query = connection.query('update game_user set ? where user_id=?', [queryData,request.body['user_id']] ,(error, results, fields)=>{
            if(error) 
                console.log(error);
            else
                response.json({'message': "User info updated correctly."})
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});

//This API call updates the game_user_scores of a specific user. Since the update structure need to have the key identificator (user_id) in order to make updates on specific columns we need to extract it from the request as well as 'user_name' because it is not requiered in the update query
app.put('/api/game_user/scores', (request, response)=>{
    try{
        let connection = connectToDB();
        connection.connect();
        //Create data without user_id and user_name
        const data = Object.entries(request.body).filter(([k,v])=> k!='user_name' & k!= 'user_id');
        //Create queryData in order to send the data when doing the query
        const queryData = Object.fromEntries(data);
        //When doing the query we must send a list containing the new data as well as the user_id from the original request
        const query = connection.query('update game_user_scores set ? where user_id=?', [queryData,request.body['user_id']], (error, results, fields)=>{
            if(error) 
                console.log(error);
            else
                response.json({'message': "User scores updated correctly."})
        });
        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});

//This API call updates the user record in the table game_user_save_file
app.put('/api/game_user/sf', (request, response)=>{
    try{
        let connection = connectToDB();
        connection.connect();
        //Create data without user_id and user_name
        const data = Object.entries(request.body).filter(([k,v])=> k!='user_name' & k!= 'user_id');
        //Create queryData in order to send the data when doing the query
        const queryData = Object.fromEntries(data);
        //When doing the query we must send a list containing the new data as well as the user_id from the original request
        const query = connection.query('update game_user_save_file set ? where user_id = ?', [queryData, request.body['user_id']] ,(error, results, fields)=>{
            if(error) 
                console.log(error);
            else
                response.json({'message': "User updated correctly."})
        });
        //se puede hacer solo un update en lugar de todos?
        //como agregar query para comparar con best score? y sumar al tiempo
        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});

//This API call updates a specific question from the table question depending on its key identificator (question_id)
app.put('/api/questions', (request, response)=>{
    try{
        let connection = connectToDB();
        connection.connect();

        const query = connection.query('update questions set question = ?, cor_answer = ?, answer_2 = ?, answer_3 = ?, answer_4 = ? where question_id= ?', [request.body['question'], request.body['cor_answer'], request.body['answer_2'], request.body['answer_3'], request.body['answer_4'], request.body['question_id']] ,(error, results, fields)=>{
            if(error) 
                console.log(error);
            else
                response.json({'message': "Data updated correctly."})
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});

//This API call deletes a specific user from the table game_user. It is important to mention that once a user is deleted, all the other records from the tables that contain the same foreign key will be deleted as well (DELETE ON CASCADE)
app.delete('/api/game_user', (request, response)=>{
    try
    {
        let connection = connectToDB();
        connection.connect();

        const query = connection.query('delete from game_user where user_id= ?', request.body['user_id'] ,(error, results, fields)=>{
            if(error) 
                console.log(error);
            else
                response.json({'message': "Data deleted correctly."})
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});

//This API call deletes a specific user_score from the table game_user_scores depending on the identifaction key (user_id).
app.delete('/api/game_user/scores', (request, response)=>{
    try
    {
        let connection = connectToDB();
        connection.connect();

        const query = connection.query('delete from game_user_scores where user_id= ?', request.body ,(error, results, fields)=>{
            if(error) 
                console.log(error);
            else
                response.json({'message': "Data deleted correctly."})
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});

//This API call deletes a specific user_key_iventory from the table game_user_key_inventory depending on the identifaction key (user_id).
app.delete('/api/game_user/key_inventory', (request, response)=>{
    try
    {
        let connection = connectToDB();
        connection.connect();

        const query = connection.query('delete from game_user_key_inventory where user_id= ?', request.body ,(error, results, fields)=>{
            if(error) 
                console.log(error);
            else
                response.json({'message': "Data deleted correctly."})
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});

//This API call deletes a specific user save file from the table game_user_save_file depending on the identifaction key (user_id).
app.delete('/api/game_user/sf', (request, response)=>{
    try
    {
        let connection = connectToDB();
        connection.connect();

        const query = connection.query('delete from game_user_save_file where user_id= ?', request.body ,(error, results, fields)=>{
            if(error) 
                console.log(error);
            else
                response.json({'message': "Data deleted correctly."})
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});

//This API call deletes a specific question from the table questions depending on the identifaction key (question_id).
app.delete('/api/questions', (request, response)=>{
    try
    {
        let connection = connectToDB();
        connection.connect();

        const query = connection.query('delete from questions where question_id= ?', [request.body['question_id']] ,(error, results, fields)=>{
            if(error) 
                console.log(error);
            else
                response.json({'message': "Data deleted correctly."})
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
})

app.listen(port, ()=>
{
    console.log(`App listening at http://localhost:${port}`);
});


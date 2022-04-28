"use strict"

import express, { response } from 'express'
import mysql from 'mysql'
import fs from 'fs'
import { request } from 'http';

const app = express();
const port = 5000;

app.use(express.json());

app.use('/js', express.static('./js'))
app.use('/css', express.static('./css'))

function connectToDB()
{
    try{
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

app.get('/', (request,response)=>{
    //aqui iba la direcciona gameUsers.html
    fs.readFile('./html/home.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err);
        console.log('Loading page...');
        response.send(html);
    })
});

app.get('/game_user', (request,response)=>{
    //aqui iba la direcciona gameUsers.html
    fs.readFile('./html/gameUsers.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err);
        console.log('Loading page...');
        response.send(html);
    })
});

app.get('/questions', (request,response)=>{
    //aqui iba la direcciona gameUsers.html
    fs.readFile('./html/questions.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err);
        console.log('Loading page...');
        response.send(html);
    })
});

app.get('/game_user/scores', (request,response)=>{
    fs.readFile('./html/userScores.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err);
        console.log("Loading page...");
        response.send(html)
    })
});

app.get('/game_user/key_inventory', (request,response)=>{
    fs.readFile('./html/gameUsersKI.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err);
        console.log("Loading page...");
        response.send(html)
    })
});

app.get('/game_user/sf', (request,response)=>{
    fs.readFile('./html/gameUserSF.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err);
        console.log("Loading page...");
        response.send(html)
    })
});


app.post('/api/game_user/verify', (request,response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('SELECT COUNT(1) from game_user where user_name=?', request.body['user_name'], (error, results, fields)=>{
            if(error) console.log(error);
            console.log(JSON.stringify(results[0]["COUNT(1)"]));
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

app.get('/api/game_user/password', (request,response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('SELECT COUNT 1 (user_name) from game_user where user_name=? and pwd=?', request.body, (error, results, fields)=>{
            if(error) console.log(error);
            console.log(JSON.stringify(results));
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

app.get('/api/game_user', (request, response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('select * from game_user', (error, results, fields)=>{
            if(error) console.log(error);
            console.log(JSON.stringify(results));
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


app.get('/api/game_user/scores', (request, response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('select * from game_user_scores', (error, results, fields)=>{
            if(error) console.log(error);
            console.log(JSON.stringify(results));
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



app.get('/api/game_user/key_inventory', (request,response)=>{
    let connection = connectToDB();
    try{

        connection.connect();

        connection.query('select * from game_user_key_inventory', (error, results, fields)=>{
            if(error) console.log(error);
            console.log(JSON.stringify(results));
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

app.get('/api/game_user/sf', (request,response)=>{
    let connection = connectToDB();
    try{

        connection.connect();

        connection.query('select * from game_user_save_file', (error, results, fields)=>{
            if(error) console.log(error);
            console.log(JSON.stringify(results));
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

app.get('/api/questions', (request, response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('select * from questions', (error, results, fields)=>{
            if(error) console.log(error);
            console.log(JSON.stringify(results));
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


app.get('/api/top-scores/rhythm', (request, response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('select * from top_rhythm_scores', (error, results, fields)=>{
            if(error) console.log(error);
            console.log(JSON.stringify(results));
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

app.get('/api/top-scores/trivia', (request, response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('select * from top_trivia_scores', (error, results, fields)=>{
            if(error) console.log(error);
            console.log(JSON.stringify(results));
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

app.get('/api/top-scores/memory', (request, response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('select * from top_memory_scores', (error, results, fields)=>{
            if(error) console.log(error);
            console.log(JSON.stringify(results));
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

app.get('/api/top-scores/memorysounds', (request, response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('select * from top_memory_scores', (error, results, fields)=>{
            if(error) console.log(error);
            console.log(JSON.stringify(results));
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




app.post('/api/game_user', (request, response)=>{

    try{
        console.log(request.headers);

        let connection = connectToDB();
        connection.connect();

        const query = connection.query('insert into game_user set ?', request.body ,(error, results, fields)=>{
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

app.post('/api/game_user/sf', (request, response)=>{

    try{
        console.log(request.headers);

        let connection = connectToDB();
        connection.connect();

        const query = connection.query('insert into game_user_save_file set ?', request.body ,(error, results, fields)=>{
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


app.post('/api/questions', (request, response)=>{

    try{
        console.log(request.headers);

        let connection = connectToDB();
        connection.connect();

        const query = connection.query('insert into questions set ?', request.body ,(error, results, fields)=>{
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

app.put('/api/game_user', (request, response)=>{
    try{
        let connection = connectToDB();
        connection.connect();
        //Como logro que aun cuando no se inserten todos los valores se pueda hacer el update (solo user_name)
        const query = connection.query('update game_user set ?', request.body ,(error, results, fields)=>{
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

app.put('/api/game_user/scores', (request, response)=>{
    try{
        let connection = connectToDB();
        connection.connect();
        //Modificar solo un minijuego a la vez
        const query = connection.query('update game_user_scores set ? where user_name=?', [request.body,user], (error, results, fields)=>{
            if(error) 
                console.log(error);
            else
                response.json({'message': "User scores updated correctly."})
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

app.put('/api/game_user/sf', (request, response)=>{
    try{
        let connection = connectToDB();
        connection.connect();
        //Modificar solo un minijuego a la vez
        const query = connection.query('update game_user_save_file set ? where user_name=?', [request.body,user] ,(error, results, fields)=>{
            if(error) 
                console.log(error);
            else
                response.json({'message': "Data updated correctly."})
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

app.delete('/api/game_user', (request, response)=>{
    try
    {
        let connection = connectToDB();
        connection.connect();

        const query = connection.query('delete from game_user where user_name= ?', request.body ,(error, results, fields)=>{
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

app.delete('/api/game_user/scores', (request, response)=>{
    try
    {
        let connection = connectToDB();
        connection.connect();

        const query = connection.query('delete from game_user_scores where user_name= ?', request.body ,(error, results, fields)=>{
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

app.delete('/api/game_user/key_inventory', (request, response)=>{
    try
    {
        let connection = connectToDB();
        connection.connect();

        const query = connection.query('delete from game_user_key_inventory where user_name= ?', request.body ,(error, results, fields)=>{
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

app.delete('/api/game_user/sf', (request, response)=>{
    try
    {
        let connection = connectToDB();
        connection.connect();

        const query = connection.query('delete from game_user_save_file where user_name= ?', request.body ,(error, results, fields)=>{
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


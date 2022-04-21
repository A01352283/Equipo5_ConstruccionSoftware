"use strict"

import express from 'express'
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

app.get('/game_user/key_inventory', (request,respone)=>{
    fs.readFile('./html/questions.html', 'utf8', (err, html)=>{
        if(err) respone.status(500).send('There was an error: ' + err);
        console.log("Loading page...");
        respone.send(html)
    })
});

app.get('/game_user/key_inventory', (request,respone)=>{
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

app.get('/questions', (request,respone)=>{
    fs.readFile('./html/questions.html', 'utf8', (err, html)=>{
        if(err) respone.status(500).send('There was an error: ' + err);
        console.log("Loading page...");
        respone.send(html)
    })
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

        const query = connection.query('update game_user set user_name = ?, pwd = ? where user_id= ?', [request.body['user_name'], request.body['pwd'], request.body['user_id']] ,(error, results, fields)=>{
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

        const query = connection.query('delete from game_user where user_id= ?', [request.body['userID']] ,(error, results, fields)=>{
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
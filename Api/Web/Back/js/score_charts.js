import {Chart, registerables} from '/scripts/charts/chart.esm.js'
Chart.register(...registerables);

/**
 * @param {number} alpha Indicated the transparency of the color
 * @returns {string} A string of the form 'rgba(240, 50, 123, 1.0)' that represents a color
 */
function random_color(alpha=1.0)
{
    const r_c = () => Math.round(Math.random() * 255)
    return `rgba(${r_c()}, ${r_c()}, ${r_c()}, ${alpha}`
}

// We obtain a reference to the canvas that we are going to use to plot the chart.
const ctx = document.getElementById('memory_top_Chart').getContext('2d');
const ctx2 = document.getElementById('trivia_top_Chart').getContext('2d');
const ctx3 = document.getElementById('rhythm_top_Chart').getContext('2d');
const ctx4 = document.getElementById('memorysounds_top_Chart').getContext('2d');
const ctx5 = document.getElementById('top_play_Chart').getContext('2d');


// To plot data from an API, we first need to fetch a request, and then process the data.
try
{
    const scores_response = await fetch('http://localhost:5000/api/top-scores/memory',{
        method: 'GET'
    })

    console.log('Got a response correctly')

    if(scores_response.ok)
    {
        console.log('Response is ok. Converting to JSON.')

        let results = await scores_response.json()

        console.log('Data converted correctly. Plotting chart.')
        
        const values = Object.values(results)

        // In this case, we just separate the data into different arrays using the map method of the values array. This creates new arrays that hold only the data that we need.
        const user_names = values.map(e => e['user_name'])
        const level_colors = values.map(e => random_color(0.8))
        const best_score = values.map(e => e['memory_best_score'])

        const ctx_top_memory_score = document.getElementById('memory_top_Chart').getContext('2d');
        const top_memory_chart = new Chart(ctx_top_memory_score, 
            {
                type: 'bar',
                data: {
                    labels: user_names,
                    datasets: [
                        {
                            label: 'Score',
                            backgroundColor: level_colors,
                            data: best_score
                        }
                    ]
                }
            })
    }
}
catch(error)
{
    console.log(error)
}


try
{
    const scores_response = await fetch('http://localhost:5000/api/top-scores/trivia',{
        method: 'GET'
    })

    console.log('Got a response correctly')

    if(scores_response.ok)
    {
        console.log('Response is ok. Converting to JSON.')

        let results = await scores_response.json()

        console.log('Data converted correctly. Plotting chart.')
        
        const values = Object.values(results)

        // In this case, we just separate the data into different arrays using the map method of the values array. This creates new arrays that hold only the data that we need.
        const user_names = values.map(e => e['user_name'])
        const level_colors = values.map(e => random_color(0.8))
        const best_score = values.map(e => e['trivia_best_score'])
        console.log(best_score);

        const ctx_top_trivia_score = document.getElementById('trivia_top_Chart').getContext('2d');
        const top_trivia_chart = new Chart(ctx_top_trivia_score, 
            {
                type: 'bar',
                data: {
                    labels: user_names,
                    datasets: [
                        {
                            label: 'Score',
                            backgroundColor: level_colors,
                            data: best_score
                        }
                    ]
                }
            })
    }
}
catch(error)
{
    console.log(error)
}

try
{
    const scores_response = await fetch('http://localhost:5000/api/total_play_time',{
        method: 'GET'
    })

    console.log('Got a response correctly')

    if(scores_response.ok)
    {
        console.log('Response is ok. Converting to JSON.')

        let results = await scores_response.json()

        console.log('Data converted correctly. Plotting chart.')
        
        const values = Object.values(results)

        // In this case, we just separate the data into different arrays using the map method of the values array. This creates new arrays that hold only the data that we need.
        const memory_time = values.map(e => e['total_memory_play_time'])
        const level_colors = values.map(e => random_color(0.8))
        const trivia_time = values.map(e => e['total_trivia_play_time'])
        const memorysounds_time = values.map(e => e['total_memorysounds_play_time'])
        const rhythm_time = values.map(e => e['total_rhythm_play_time'])
        const ctx_top_play_chart = document.getElementById('top_play_Chart').getContext('2d');
        const top_play_chart = new Chart(ctx_top_play_chart, 
            {
                type: 'bar',
                data: {
                    labels: ['total_memory_play_time','total_trivia_play_time','total_memorysounds_play_time','total_rhythm_play_time'],
                    datasets: [
                        {
                            label: 'Time Played',
                            backgroundColor: level_colors,
                            data: [memory_time[0], trivia_time[0], memorysounds_time[0], rhythm_time[0]]
                        }
                    ]
                }
            })
    }
}
catch(error)
{
    console.log(error)
}
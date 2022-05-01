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
        const best_score = values.map(e => e['best_memory_score'])

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
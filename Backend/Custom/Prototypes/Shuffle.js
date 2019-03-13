// To be deleted later on
// No clear use for real implementation
function Shuffle(){
    let count = 0
    while(count < 30){
        let left = Math.floor(Math.random()*52)
        let right = Math.floor(Math.random()*52)
        let random = left + right
        random = random%52
        console.log(random)
        count++
    }
    console.log("Shuffle")
}
function Duffle(){
    let count = 0
    while(count < 30){
        let random = Math.floor(Math.random()*52)
        console.log(random)
        count++
    }
    console.log("Duffle")
}
Shuffle()
Duffle()
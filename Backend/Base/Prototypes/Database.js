// This is the prototype for the Database tracker on the poker project
// This is done so we keep track of the number of simulations we need to keep doing

function Race(array, limit){
  console.log(array)
  let count = 0
  const length = array.length
  while (count<limit){
    array[Math.floor(Math.random(length)*length)]++
    count++;
    index++;
  }
  console.log(array)
  return array
}
function Check(array, stopper){
  var popstar=[array.length*stopper]
  while(array.length>0){
    let length = array.length;
    array = Race(array, popstar[popstar.length-1]);
    var min = array[0]
    for(let i = 0; i < length; i++){
      if(array[i]>=stopper){
        array.splice(i,1);
        i--
        length--
      }
      else if(array[i]<min){
        min = array[i]
      }
    }
    console.log(index)
    popstar.push((stopper-min)*array.length)
  }
  console.log("Finito")
}
function Test(){
  
}
var index = 0
array = [0,0,0,0,0,0,0,0,0,0]
Check(array,25);
// This is the prototype for the combinatorics involved in analyzing poker hands for each player
var arr = [0,1,2,3,4,5,6]
var count = 0
for(var i = 0; i < arr.length-1; i++)
{
    for(var j = i+1; j < arr.length; j++){
        var hot = []
        var k = 0
        while(k < 7)
        {
            if(k === j || k === i){}
            else{
                hot.push(k)
            }
            k++
        }
        console.log(hot)
    }
}
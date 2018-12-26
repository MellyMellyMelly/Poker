function Pair(arr)
{
    var hot
    for(var i = arr.length-1; i > 0; i--){
      if(arr[i-1] == arr[i]){
        hot=arr[i-1]
        arr.splice(i-1,2)
        return [arr,hot]
      }
    }
}
console.log(Pair([2,3,3,4,5]))

function TwoPair(arr)
{
    var hot = []
    for(var i = 0; i < arr.length; i++){
      if(arr[i] == arr[i+1]){
        hot.push(arr[i])
        arr.splice(i,2)
        i--
      }
    }
    return [arr[0],hot]
}
console.log(TwoPair([2,3,3,4,4]))

function ThreeOfKind(arr)
{
  var hot
  for(var i = 0; i < 3; i++){
    if(arr[i] == arr[i+1]){
      hot = arr[i]
      arr.splice(i,3)
      return [arr,hot]
    }
  }
}
console.log(ThreeOfKind([2,3,3,3,4]))

function Straight(arr)
{
  if(arr[4]%13==arr[0]-1){
    return arr[3]
  }
  else{
    return arr[4]
  }
}
console.log(Straight([2,3,4,5,14]))
console.log(Straight([2,3,3,3,6]))

function FullHouse(arr)
{
  if(arr[1]==arr[2]){
    return [arr[3],arr[1]]
  }
  else{
    return [arr[1],arr[2]]
  }
}
console.log(FullHouse([2,2,2,3,3]))
console.log(FullHouse([2,2,3,3,3]))

function FourOfKind(arr)
{
  return arr[2]
}
console.log(FourOfKind([2,2,2,2,3]))
console.log(FourOfKind([2,3,3,3,3]))
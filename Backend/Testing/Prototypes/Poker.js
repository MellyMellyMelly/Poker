// This is the prototype for the rank functions we are going to invoke in the poker app
var deck=[];
var suit=['diamond','heart','club','spade'];
for(var rank=2;rank<=14;rank++){
  for(var i=0;i<suit.length;i++){
    deck.push([rank,suit[i]])
  }
}
var handOne=[deck[2],deck[37],deck[41],deck[45],deck[49]];
function straight(arr){
  var stopper=arr.length-1;
  for(var a=0;a<stopper;a++){
    for(var b=0;b<stopper;b++){
      if(arr[b][0]>arr[b+1][0]){
        var temp=arr[b];
        arr[b]=arr[b+1];
        arr[b+1]=temp
      }
    }
  }
  var streak=0;
  var breaker=0;
  for(var c=0;c<stopper+1;c++){
    if(c<stopper){
      if(arr[c+1][0]-arr[c][0]==1){
        streak++
        if(streak==4){
          return [arr,true]
        }
      }
      else{
        if(arr[c+1][0]==14||(arr[c+1][0]-arr[c][0]==0)){
        }
        else(streak=0)
      }
    }
    else{
      if(arr[0][0]-((arr[arr.length-1][0])%13)==1){
        streak=1;
        c=-1
      }
    }
  }
  return [arr,false]
}
straight(handOne);
function flush(arr){
  var count=0;
  var stopper=arr.length-1;
  for(var a=0;a<stopper;a++){
    if(arr[a][1]==arr[a+1][1]){
      count++;
      if(count==4){
        return [arr,true]
      }
    }
  }
  return [arr,false]
}
flush(handOne);
function commonRank(arr){
  var table=[1];
  var streak=0;
  var sum=0;
  for (var i=1;i<arr.length;i++){
    if(arr[i-1]==arr[i]){
      streak++;
      table[table.length-1]=Math.pow(streak+1,streak+1)
    }
    else{
      table[table.length-1]+=(arr[i-1]/100);
      table.push(1);
      streak=0
    }
  }
  for (var j=0;j<table.length;j++){
    sum+=table[j]
  }
  if(sum<8){
    return "High Card"
  }
  else if(sum<10){
    return "Pair"
  }
  else if(sum<14){
    return "Two Pair"
  }
  else if(sum<32){
    return "Three of a Kind"
  }
  else if(sum<36){
    return "Full House"
  }
  else{
    return "Four of Kind"
  }
}
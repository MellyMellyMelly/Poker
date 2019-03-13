// This is for sorting cards before discarding those cards to the user themself
function InsertSort(one, two)
{
    let newArray = []
    let left = 0
    let right = 0
    while(left < one.length && right < two.length)
    {
        if(one[left] > two[right])
        {
            newArray.push(two[right])
            right++
        }
        else
        {
            newArray.push(one[left])
            left++
        }
    }
    if(right = two.length)
    {
        FinishOff(one, newArray, left)
    }
    else
    {
        FinishOff(two, newArray, right)
    }
    return newArray
}
function FinishOff(original, newA, num)
{
    while(num < original.length)
    {
        newA.push(original[num])
        num++
    }
    return newA
}
var test1 = [22,49]
var test2 = [11,20,35,43,56]
baby = InsertSort(test1,test2)
console.log(baby)
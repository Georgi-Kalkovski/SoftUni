function PieceOfPie(arr, flavor1, flavor2) {

    let myArr = [];
    let index1 = arr.indexOf(flavor1);
    let index2 = arr.indexOf(flavor2);
    
    for(let i = index1; i <= index2;i++)
    {
        myArr.push(arr[i]);
    }

    return myArr;
}

console.log(PieceOfPie(['Pumpkin Pie',
    'Key Lime Pie',
    'Cherry Pie',
    'Lemon Meringue Pie',
    'Sugar Cream Pie'],
    'Key Lime Pie',
    'Lemon Meringue Pie'
));
console.log(PieceOfPie(['Apple Crisp',
    'Mississippi Mud Pie',
    'Pot Pie',
    'Steak and Cheese Pie',
    'Butter Chicken Pie',
    'Smoked Fish Pie'],
    'Pot Pie',
    'Smoked Fish Pie'
));
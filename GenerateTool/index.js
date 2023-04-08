


const getRD = (min, max) => {
    max += 1;
    return Math.floor(Math.random() * (max - min) + min);
}


let a = [11, 12, 13, 14, 15];
let b = [21, 22, 23, 24, 25, 26, 27];
let c = [31, 32, 33, 34, 35, 36, 37];
let d = [41, 42, 43, 44, 45, 46, 47];
let e = [51, 52, 53, 54, 55, 56, 57];
let f = [61, 62, 63, 64, 65, 66, 67];
let g = [71, 72, 73, 74, 75, 76, 77];

// percent target;
let a1 = [38, 28, 18, 10, 6];
let b1 = [30, 25, 20, 10, 7, 5, 3];
let c1 = [30, 25, 20, 10, 7, 5, 3];
let d1 = [35, 30, 24, 8, 3, 0, 0];
let e1 = [30, 25, 20, 10, 7, 5, 3];
let f1 = [30, 25, 20, 10, 7, 5, 3];
let g1 = [30, 25, 20, 10, 7, 5, 3];


//src 
const Percentage = (a, b) => {
    return (a * b) / 100;
}
const PercentageCal = (arr, num) => {
    let rs = [];
    for (let i = 0; i < arr.length; i++) {
        rs.push(Percentage(arr[i], num))
    }
    return rs;
}


// 2000 target
let target = 2000;
let a2 = PercentageCal(a1, target);
let b2 = PercentageCal(b1, target);
let c2 = PercentageCal(c1, target);
let d2 = PercentageCal(d1, target);
let e2 = PercentageCal(e1, target);
let f2 = PercentageCal(f1, target);
let g2 = PercentageCal(g1, target);

console.log(a2);
console.log(b2);
console.log(c2);
console.log(d2);
console.log(e2);


//same length
const CompareTwoArr = (arr1, arr2) => {
    let rs = true;
    for (let i = 0; i <= arr1.length; i++) {
        if (arr1[i] !== arr2[i]) rs = false;
    }
    return rs;
}


const Combinaions = (...args) => {
    let result = [], max = args.length - 1;
    const helper = (arr, i) => {
        for (let j = 0, l = args[i].length; j < l; j++) {
            let a = arr.slice(0);
            a.push(args[i][j]);
            if (i == max) {
                 if (Validator(a, result)) {
                    result.push(a);
                 }
            }
            else
                helper(a, i + 1);
        }
    }
    helper([], 0);
    return result;
}
//let b1 = [30,25,20,10,7,5,3];
const Validator = (arr, result) => {
    let _result = true;
    for (let i = 0; i < arr.length; i++) {
        if (NumExistCheck(arr[i], result, i)) _result = false;
    }

    return _result;
}

const NumExistCheck = (num, rs, pos) => {
    let result;
    let arrToTest;
    switch (pos) {
        case 0: arrToTest = a2;
            break;
        case 1: arrToTest = b2;
            break;
        case 2: arrToTest = c2;
            break;
        case 3: arrToTest = d2;
            break;
        case 4: arrToTest = e2;
            break;
        case 5: arrToTest = f2;
            break;
        case 6: arrToTest = g2;
            break;
        default: arrToTest = null;
    }
    let numExist = 0;
    rs.forEach(a => {
        a.forEach(b => {
            if( b == num) numExist += 1;
        })
    })
    let targetPosA = parseInt((num/10).toString()[(num/10).toString().length-1]);
    if(numExist > arrToTest[targetPosA]) result = true;
    return result;
}




let ars = Combinaions(a, b, c, d, e, f, g);

let csvContent = "data:text/csv;charset=utf-8,";

ars.forEach(function (rowArray) {
    let row = rowArray.join(",");
    csvContent += row + "\r\n";
});



var encodedUri = encodeURI(csvContent);
// var link = document.createElement("a");
let link = document.querySelector("#download");
link.setAttribute("href", encodedUri);
link.setAttribute("download", "4ndrvGen.csv");
// document.body.appendChild(link);
// link.addEventListener("click", => {

// })
//link.click(); 


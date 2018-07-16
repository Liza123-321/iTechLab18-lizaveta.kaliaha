var Robot = function (name) {
    this.name = name;
}

function add (op1, op2) {
    this.name = this.name || "Human";
    return  this.name + " can count to " + (op1 + op2);
}

var voltron = new Robot("Voltron");

//1
console.log(add(1,0));

//2
console.log(add.call(voltron,1,2));

//3
console.log(add.apply(voltron,[20,30]));

//4
 console.log(add.bind(voltron)("drinking","beer"));

 //5

var mini = (number) => {
    var str = number.toString()
  let len = str.length;
  let index = -1;

  for (let i = len - 2; i >= 0; i--) {
    if (str[i] > str[i + 1]) {
      index = i;
      break;
    }
  }

  let smallGreatDgt = -1;
  for (let i = len - 1; i > index; i--) {
    if (str[i] < str[index]) {
      if (smallGreatDgt == -1) {
        smallGreatDgt = i;
      } else if (str[i] >= str[smallGreatDgt]) {
        smallGreatDgt = i;
      }
    }
  }

  if (index == -1) {
    return "-1";
  }

  if (smallGreatDgt != -1) {
    str = swap(str, index, smallGreatDgt);
    return str;
  }

  return "-1";
};

function swap(arr, i, j) {
  var temp = arr.split("");
  var c = temp[i];
  temp[i] = temp[j];
  temp[j] = c;
  return temp.join("");
}

var maxi = (number) => {
  var max_digit = -1;
  var max_digit_indx = -1;
  var l_indx = -1;
  var r_indx = 1;
  var num_in_str = number.toString();
  for (var i = num_in_str.length - 1; i >= 0; i--) {
      
    if (num_in_str.charAt(r_indx) > max_digit) {
      max_digit = num_in_str.charAt(i);
      max_digit_indx = i;
      continue;
    }

    if (num_in_str.charAt(i) < max_digit) {
      l_indx = i;
      r_indx = max_digit_indx;
    }
  }

  if (l_indx == -1) return number;

  num_in_str = swap(num_in_str, l_indx, r_indx);

  return parseInt(num_in_str);
};

function maximini(number) {
  return [maxi(number), mini(number)];
}

console.log(maximini(12340));
console.log(maximini(98761));
console.log(maximini(9000));
console.log(maximini(357758017083851));

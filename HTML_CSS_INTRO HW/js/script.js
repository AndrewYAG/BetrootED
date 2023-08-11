function showSkillList(e) {
    document.getElementById('skillsContainer').style = "display: block;";
    document.getElementById('showSkillsButton').innerText = 'Hide Skills';
    document.getElementById('showSkillsButton').style = 'background-color: red;';
    document.getElementById('showSkillsButton').onclick = hideSkillList;
}

function hideSkillList(e) {
    document.getElementById('skillsContainer').style = 'display: none;';
    document.getElementById('showSkillsButton').innerText = 'Show Skills';
    document.getElementById('showSkillsButton').style = 'background-color: cornflowerblue;';
    document.getElementById('showSkillsButton').onclick = showSkillList;
}

let amountOfBackgourndColorChanges = 0;

function changeBodyBackgroundColor(e) {
    amountOfBackgourndColorChanges++;

    if (amountOfBackgourndColorChanges % 2 === 0) {
        document.getElementById('changeBackgroundColorButton').innerHTML = 'White Background ' + amountOfBackgourndColorChanges;
        document.getElementsByTagName('body')[0].style = 'background-color: #ddd;';
    } else {
        document.getElementById('changeBackgroundColorButton').innerHTML = 'Red Background ' + amountOfBackgourndColorChanges;
        document.getElementsByTagName('body')[0].style = 'background-color: red;';
    }
}

document.getElementById('showSkillsButton').onclick = showSkillList;
document.getElementById('changeBackgroundColorButton').onclick = changeBodyBackgroundColor;


//document.getElementById('showSkillsButton').style = 'color: red';
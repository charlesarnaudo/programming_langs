Array.prototype.pushIfDoesntExist = function (item) {
    if (this.indexOf(item) === -1) {
        this.push(item);
        return true;
    } else {
        return false;
    }
}

var Testing = {
    clickedList: [],
    applyListeners: function() {
        var self = this;
        var ul = document.getElementsByTagName('ul')[0];
        function updateDisplay(e) {
            // Only update display if change has been made and target type is
            // a list element
            if (self.clickedList.pushIfDoesntExist(e.target.textContent) &&
                e.target.tagName === "LI")
                self.displayData();
        }
        // Attach event listener to unordered list
        ul.addEventListener('click', updateDisplay, false);
    },
    displayData: function() {
        var textBox = document.getElementById('clickedElements');
        textBox.textContent = this.clickedList.join(', ');
    }
}

Testing.applyListeners();
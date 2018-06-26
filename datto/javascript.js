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
        // Get first unordered list in document
        var ul = document.querySelector("ul")
        function updateDisplay(e) {
            // Only update display if change has been made and target type is
            // not the element the listener is attached too (the ul)
            if (self.clickedList.pushIfDoesntExist(e.target.textContent) &&
                e.target !== e.currentTarget)
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
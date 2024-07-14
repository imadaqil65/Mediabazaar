// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var changeBtn = document.getElementById('Profile-button');

function removeReadonly() {
    var form = document.getElementById('Profile-form');

    var readonlyInputs = form.querySelectorAll('input[readonly]');

    for (var i = 0; i < readonlyInputs.length; i++) {
        readonlyInputs[i].removeAttribute('readonly');
    }
}


/*document.addEventListener('DOMContentLoaded', function () {
    var initialDuration = parseFloat(getComputedStyle(document.documentElement).getPropertyValue('--initial-duration'));

    // Initialize the countdown
    var remainingTime = parseFloat(getCookie('remainingTime')) || initialDuration;
    var intervalId;

    var resetButton = document.getElementById('resetButton');
    resetButton.addEventListener('click', function () {
        resetCountdown();
    })

    // Start button click event
    var startButton = document.getElementById('startButton');
    startButton.addEventListener('click', function () {
        // Start the countdown
        startCountdown();
    });

    // Stop button click event
    var stopButton = document.getElementById('stopButton');
    stopButton.addEventListener('click', function () {
        // Stop the countdown
        stopCountdown();
    });

    // Function to start the countdown
    function startCountdown() {
        // If the interval is not already running
        if (!intervalId) {
            startButton.disabled = true;
            intervalId = setInterval(function () {
                // Decrease the remaining duration
                remainingTime--;

                // Store remaining time in the cookie
                document.cookie = 'remainingTime=' + remainingTime + '; path=/';

                // Update the countdown
                updateCountdown(remainingTime);

                // Check if the countdown has reached zero
                if (remainingTime <= 0) {
                    // Optionally, you can perform additional actions when the countdown reaches zero.
                    stopCountdown(); // Stop the countdown
                }
            }, 1000); // Update every second
        }
    }

    // Function to stop the countdown
    function stopCountdown() {
        // If the interval is currently running, stop it
        if (intervalId) {
            clearInterval(intervalId);
            intervalId = undefined;
            startButton.disabled = false;
        }
    }

    // Function to update the countdown display
    function updateCountdown(time) {
        var hours = Math.floor(time / 3600);
        var minutes = Math.floor((time % 3600) / 60);
        var seconds = time % 60;

        // Display the countdown
        var countdownElement = document.getElementById('countdown');
        countdownElement.innerHTML = hours + 'h ' + minutes + 'm ' + seconds + 's';
    }

    function resetCountdown() {
        var userConfirmation = confirm("Are you sure you want to reset the timer?");

        var messageElement = document.getElementById('message');

        if (userConfirmation) {
            remainingTime = initialDuration;
            stopCountdown();
            messageElement.innerHTML = "Timer reset!";
        } else {
            messageElement.innerHTML = "Reset canceled!";
        }

        setTimeout(function () {
            messageElement.innerHTML = "";
        }, 5000);
    }

    // Function to get the value of a cookie
    function getCookie(name) {
        var cookies = document.cookie.split(';');
        for (var i = 0; i < cookies.length; i++) {
            var cookie = cookies[i].trim();
            if (cookie.startsWith(name + '=')) {
                return cookie.substring(name.length + 1);
            }
        }
        return null;
    }
});*/



/**
 * Gets a random name.
 * @returns {string} a random first name and last name.
 */
function getRandomName() {
    let firstNames = ["James", "Jack", "Damon", "Jessica", "Maria", "Liam", "Dan", "Dale", "Oliver"]
    let lastNames = ["Andrews", "Brown", "Smith", "Parry", "Richards", "Shepherd", "Armstrong"]

    let randomNumber = Math.floor(Math.random() * firstNames.length);
    let randomNumber2 = Math.floor(Math.random() * lastNames.length);
    return firstNames[randomNumber] + " " + lastNames[randomNumber2];
}

/**
 * Converts a score to the string counterpart.
 * @param {int} score 
 * @returns the string of the score.
 */
function convertScoreToString(score) {
    switch (score) {
        case 0:
            return "love"
        case 1:
            return "fifteen"
        case 2:
            return "thirty"
        case 3:
            return "forty"
        case 4:
            return "advantage"
        case 5:
            return "game"
        default:
            return "ERROR!"
    }
}

/**
 * Player class to represent a tennis player.
 */
class Player {

    /**
     * Constructor of the player class.
     * @param {string} name the name of the player
     */
    constructor(name) {
        this.name = name;
        this.score = 0;
    }

    /**
     * Increase score by 1.
     */
    incScore() {
        this.score++;
    }

    /**
     * Decrease score by 1.
     */
    decScore() {
        this.score--;
    }

    /**
     * Set this player to win the game.
     */
    setGame() {
        this.score = 5;
    }
}

let player1, player2
let gameCompleted = true

/**
 * Resets the game to the default state.
 */
function reset() {
    if (gameCompleted) {
        gameCompleted = false
        player1 = new Player(getRandomName())
        player2 = new Player(getRandomName())
        let playerDom = document.getElementById('players');
        let scoreboard = document.getElementById('scoreboard');
        playerDom.innerHTML = "<ul><li><div class=\"img\"></div>" + player1.name + "</li><li><div class=\"img\"></div>" + player2.name + "</li></ul>"
        scoreboard.innerHTML = ""
    }
}

/**
 * Prints the score of the players to the DOM.
 */
function printScore(winner, loser) {
    if (winner == null || loser == null) {
        return
    }

    let scoreboard = document.getElementById('scoreboard');

    let friendlyWinnerScore = convertScoreToString(winner.score)
    let friendlyLoserScore = convertScoreToString(loser.score)
    let scoreString

    // game
    if (winner.score === 5) {
        scoreString = winner.name + " has won the game. Score:" + friendlyWinnerScore + ":" + friendlyLoserScore
        gameCompleted = true
    }
    // We have a tie
    else if (winner.score === loser.score) {
        // Both are 40, therefore deuce
        if (winner.score === 3) {
            scoreString = winner.name + " has won the point. Score: Deuce!"
        }
        else {
            scoreString = winner.name + " has won the point. Score: " + friendlyWinnerScore + ":all!"
        }
    }
    else {
        scoreString = winner.name + " has won the point. Score: " + friendlyWinnerScore + ":" + friendlyLoserScore
    }

    scoreboard.innerHTML += "<p>" + scoreString + "</p>"
}

/**
 * Calculates the score of the winner and loser.
 */
function score(winner, loser) {
    if (winner == null || loser == null) {
        return
    }

    switch (winner.score) {
        case 0: // love
        case 1: // 15
        case 2: // 30
        case 4: // adv
            winner.incScore()
            break;
        case 3: // 40
            if (loser.score <= 2) {
                // winner has won.
                winner.setGame()
            }
            else if (loser.score === 3) {
                // winner gets the advantage.
                winner.incScore()
            }
            else if (loser.score === 4) {
                // loser loses the advantage.
                loser.decScore()
            }
            break;
        default:
            throw "winner score is out of bounds"
    }

    printScore(winner, loser)
}

/**
 * Picks a random winner.
 */
function updateRandomWinner() {
    let randomPlayerIndex = Math.floor(Math.random() * 2)
    let winner, loser
    if (randomPlayerIndex === 0) {
        winner = player1
        loser = player2
    }
    else if (randomPlayerIndex === 1) {
        loser = player1
        winner = player2
    }

    score(winner, loser)
}

/**
 * Plays the game.
 */
function play() {
    reset()
    while (!gameCompleted) {
        updateRandomWinner();
    }
}

reset()
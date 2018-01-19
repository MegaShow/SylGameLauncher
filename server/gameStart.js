/**
 * Game Start
 *
 * @example
 *  - npm run start ${gameName}
 *
 * @param {String} gameName
 */

const fs = require('fs')
const readline = require('readline')
const wait = readline.createInterface({
  input: process.stdin,
  output: process.stdout
})
const gamePath = '../database/game.json'
const playPath = '../database/play.json'
const gameName = process.argv[2]

let gameDB = JSON.parse(fs.readFileSync(gamePath))
let playDB = JSON.parse(fs.readFileSync(playPath))

let index = -1
for (let game in gameDB) {
  if (gameName === gameDB[game].name) {
    index = game
  }
}
if (index === -1) {
  console.log('找不到该游戏 -', gameName)
  wait.close()
} else {
  let startDate = new Date()
  wait.question('回车结束:', async (answer) => {
    let endDate = new Date()
    let time = Math.floor((endDate - startDate) / 1000)
    let sec = time % 60
    let min = Math.floor(time / 60) % 60
    let hour = Math.floor(time / 3600)
    console.log('\n')
    console.log('游戏开始时间 =>', startDate)
    console.log('游戏截至时间 =>', endDate, '\n')
    console.log('游戏时间 => ', hour, 'hour,', min, 'min,', sec, 'sec')
    gameDB[index].playTime += time
    await fs.writeFileSync(gamePath, JSON.stringify(gameDB))
    playDB.push({
      id: playDB.length + 1,
      gameId: gameDB[index].id,
      gameName: gameDB[index].name,
      startDate: startDate,
      endDate: endDate,
      time: time
    })
    await fs.writeFileSync(playPath, JSON.stringify(playDB))
    wait.close()
  })
}

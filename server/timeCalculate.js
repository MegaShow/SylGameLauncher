/**
 * Time Calculate
 *
 * @example
 *  - npm run show
 *
 */

const fs = require('fs')
const gamePath = '../database/game.json'

let gameDB = JSON.parse(fs.readFileSync(gamePath))
gameDB.sort((a, b) => {
  return a.playTime < b.playTime
})
let index = 0
for (let game of gameDB) {
  index++
  let time = game.playTime
  let sec = time % 60
  let min = Math.floor(time / 60) % 60
  let hour = Math.floor(time / 3600)
  console.log(`${index}.${game.name}`)
  console.log(`    游戏时间 => ${hour} hour, ${min} min, ${sec} sec`)
}

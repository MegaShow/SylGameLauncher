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
  return parseInt(b.playTime) - parseInt(a.playTime)
})
let index = 0
let allTime = 0
for (let game of gameDB) {
  index++
  let time = game.playTime
  allTime += time
  if (time === 0) break
  let sec = time % 60
  let min = Math.floor(time / 60) % 60
  let hour = Math.floor(time / 3600)
  console.log(`${index}.${game.name}`)
  console.log(`    游戏时间 => ${hour} hour, ${min} min, ${sec} sec`)
}

let sec = allTime % 60
let min = Math.floor(allTime / 60) % 60
let hour = Math.floor(allTime / 3600)
console.log(`\n游戏总时长 => ${hour} hour, ${min} min, ${sec} sec\n`)

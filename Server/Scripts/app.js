import Alpine from 'alpinejs'
import './htmx.js'

window.Alpine = Alpine;

Alpine.start()

window.sleep = function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}
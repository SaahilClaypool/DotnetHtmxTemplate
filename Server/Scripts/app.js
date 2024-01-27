import Alpine from 'alpinejs'
import * as htmxEsm from 'htmx.org/dist/htmx.esm'
import * as idiomorphEsm from 'idiomorph/dist/idiomorph.esm'

window.Alpine = Alpine;

Alpine.start()

window.sleep = function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}
function createMorphConfig(swapStyle) {
    if (swapStyle === 'morph' || swapStyle === 'morph:outerHTML') {
        return { morphStyle: 'outerHTML' }
    } else if (swapStyle === 'morph:innerHTML') {
        return { morphStyle: 'innerHTML' }
    } else if (swapStyle.startsWith("morph:")) {
        return Function("return (" + swapStyle.slice(6) + ")")();
    }
}

htmxEsm.htmx.defineExtension('morph', {
    isInlineSwap: function (swapStyle) {
        let config = createMorphConfig(swapStyle);
        return config.swapStyle === "outerHTML" || config.swapStyle == null;
    },
    handleSwap: function (swapStyle, target, fragment) {
        let config = createMorphConfig(swapStyle);
        if (config) {
            return idiomorphEsm.Idiomorph.morph(target, fragment.children, config);
        }
    }
});
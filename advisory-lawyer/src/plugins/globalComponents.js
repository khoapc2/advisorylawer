import { Parallax } from '../components';
import { FormGroupInput, Card, DropDown, Button } from "../components/index";
/**
 * You can register global components here
 */

const globalComponents = {
  install(Vue) {
    Vue.component(Parallax.name, Parallax);
    Vue.component("fg-input", FormGroupInput);
    Vue.component("drop-down", DropDown);
    Vue.component("card", Card);
    Vue.component("p-button", Button);
  }
};

export default globalComponents;

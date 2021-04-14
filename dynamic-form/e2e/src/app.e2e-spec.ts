import { browser, element, by } from 'protractor';

/* tslint:disable:quotemark */
describe('Dynamic Form', () => {

    beforeAll(() => browser.get(''));

    it('should submit form', async () => {
      const fullNameElement = element.all(by.css('input[id=fullName]')).get(0);
      expect(await fullNameElement.getAttribute('value')).toEqual('Bombasto');

      await element.all(by.css('button')).get(0).click();
      expect(await element(by.cssContainingText('strong', 'Saved the following values')).isPresent()).toBe(true);
  });

});

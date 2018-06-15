import { RapidoERPWebPage } from './app.po';

describe('rapido-erpweb App', function() {
  let page: RapidoERPWebPage;

  beforeEach(() => {
    page = new RapidoERPWebPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});

describe('Testing Factory Http Post', function () {
    beforeEach(module('app'));
    var TripService, httpBackend;

    beforeEach(inject(function ($httpBackend, _TripService_) {
        TripService = _TripService_;
        httpBackend = $httpBackend;

    }));

    it('FactoryTestSpec', function () {
        var returnData = '$9.75';

        var trip = {
            'MinsAbvSpeed': '5',
            'MilesBlwSpeed': '2',
            'DateTime': '2010 - 10 - 08T21:30:00.000Z'
        };


        var returnedPromise = TripService.CalculateFare(trip);
       
        var result;
        returnedPromise.then(function (response) {
            result = response.data;
        });

        expect(result).toEqual(returnData);
    })


});
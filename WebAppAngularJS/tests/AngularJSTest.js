describe('App Test', function () {
    beforeEach(module('app'));

    describe('Factory Test', function () {
        var fn, httpbackend;

        beforeEach(inject(function ($httpBackend, _TripService_) {
            TripService = _TripService_;
            httpBackend = $httpBackend;
        }));

        it('FactoryTestSpec', function () {
            var expectedData = '9.75';

            var trip = {
                'trip': {
                    'MinsAbvSpeed': '5',
                    'MilesBlwSpeed': '2',
                    'DateTime': '2010 - 10 - 08T21:30:00.000Z'
                }
            };

            var dataReturn;
            TripService.CalculateFare(trip)
                .then(function (response) { dataReturn = response.data; },
                function (error) { dataReturn = 'HTTP ERROR';});

            expect(expectedData).toEqual(dataReturn);   //response undefined??
        });
    });
});
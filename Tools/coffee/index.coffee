$().ready ->
  $('.slider, .point').on 'input', ->
    changePoint $(@).attr('subject_id'), $(@).val()

changePoint = (id, point)->
  $('.point[subject_id="'+id+'"]').val(point)
  $('.slider[subject_id="'+id+'"]').val(point)

